using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public enum Direction { left, right, top, bottom, none }
    public class DynamicAndDynamicObjectsHandler
    {
        private readonly MarioGame game;
        private ObjectsManager objManager { get => game.ObjectsManager; }

        private static Dictionary<(Type, Type), Type> collisionDictionary;

        public DynamicAndDynamicObjectsHandler(MarioGame game)
        {   /* Dictionary for all possible collision cases */
            this.game = game;
            collisionDictionary = new Dictionary<(Type, Type), Type>
            {
                { (typeof(IMario), typeof(IItem)), typeof(MarioItemResponse)},
                { (typeof(IMario), typeof(IEnemy)), typeof(MarioEnemyResponse)},
                { (typeof(IEnemy), typeof(IEnemy)), typeof(EnemyEnemyResponse)},
                { (typeof(IItem), typeof(IEnemy)), typeof(ItemEnemyResponse)},
                { (typeof(IEnemy), typeof(IItem)), typeof(ItemEnemyResponse)},
            };
        }
        public void HandleCollision(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            if (collisionDictionary.TryGetValue((obj1.GetType().GetInterfaces()[0], obj2.GetType().GetInterfaces()[0]), out Type type))
                ((ICollisionResponsible)Activator.CreateInstance(type, obj1, obj2, direction)).HandleCollision();
        }
    }
}


