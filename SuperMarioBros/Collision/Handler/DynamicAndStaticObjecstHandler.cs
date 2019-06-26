using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class DynamicAndStaticObjectsHandler
    {
        private MarioGame game;
        private ObjectsManager objManager { get => game.ObjectsManager; }
        private static Dictionary<(Type, Type), Type> collisionDictionary;
        public DynamicAndStaticObjectsHandler(MarioGame game)
        {
            this.game = game;
            collisionDictionary = new Dictionary<(Type, Type), Type>
            {
                { (typeof(IMario), typeof(IBlock)), typeof(MarioBlockResponse)},
                { (typeof(IItem), typeof(IBlock)), typeof(ItemBlockResponse)},
                { (typeof(IEnemy), typeof(IBlock)), typeof(EnemyBlockResponse)}
            };
        }
        public void HandleCollision(IDynamic obj1, IStatic obj2, Direction direction)
        {
            if (collisionDictionary.TryGetValue((obj1.GetType().GetInterfaces()[0], obj2.GetType().GetInterfaces()[0]), out Type type))
                ((ICollisionResponsible)Activator.CreateInstance(type, obj1, obj2, direction)).HandleCollision();
        }

    }
}