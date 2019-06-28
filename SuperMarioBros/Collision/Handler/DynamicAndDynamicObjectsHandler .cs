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
    public class DynamicAndDynamicObjectsHandler : IHandler
    {
        private static Dictionary<(Type, Type), Type> collisionDictionary;
        public DynamicAndDynamicObjectsHandler()
        {   /* Dictionary for all possible collision cases */
            collisionDictionary = new Dictionary<(Type, Type), Type>
            {
                { (typeof(IMario), typeof(IItem)), typeof(MarioItemResponse)},
                { (typeof(IMario), typeof(IEnemy)), typeof(MarioEnemyResponse)},
                { (typeof(IEnemy), typeof(IEnemy)), typeof(EnemyEnemyResponse)},
                { (typeof(IItem), typeof(IEnemy)), typeof(ItemEnemyResponse)},
                { (typeof(IEnemy), typeof(IItem)), typeof(ItemEnemyResponse)},
            };
        }
        public void HandleCollision(IObject obj1, IObject obj2, Direction direction)
        {
            if (collisionDictionary.TryGetValue((((IDynamic)obj1).GetType().GetInterfaces()[0], ((IDynamic)obj2).GetType().GetInterfaces()[0]), out Type type))
                ((ICollisionResponsible)Activator.CreateInstance(type, obj1, obj2, direction)).HandleCollision();
        }
    }
}


