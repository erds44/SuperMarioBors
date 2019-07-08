using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public enum Direction { left, right, top, bottom, none }
    public class DynamicAndDynamicObjectsResponder : ICollisionResponder
    {
        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            if (collisionDictionary.TryGetValue((((IDynamic)mover).GetType().GetInterfaces()[0], ((IDynamic)target).GetType().GetInterfaces()[0]), out var responder))
                responder.HandleCollision(mover, target, direction);
        }

        private static Dictionary<(Type, Type), ICollisionResponder> collisionDictionary = new 
            Dictionary<(Type, Type), ICollisionResponder>
            {
                { (typeof(IMario), typeof(IItem)), new MarioItemResponder()},
                { (typeof(IMario), typeof(IEnemy)), new MarioEnemyResponder()},
                { (typeof(IEnemy), typeof(IEnemy)), new EnemyEnemyResponder()},
                { (typeof(IItem), typeof(IEnemy)), new ItemEnemyResponder()},
                { (typeof(IEnemy), typeof(IItem)), new ItemEnemyResponder()}
            };
    }
}


