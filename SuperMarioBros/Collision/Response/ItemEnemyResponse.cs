using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class ItemEnemyResponse : GeneralResponse
    {
        private readonly IObject obj1;
        private readonly IObject obj2;
        private readonly Direction direction;
        private delegate void ItemEnemyHandler(IItem item, IEnemy enemy);

        public ItemEnemyResponse(IObject obj1, IObject obj2, Direction direction)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if (direction != Direction.none)
            {
                if (handlerDictionary.TryGetValue(obj1.GetType(), out var handle1))
                    handle1((IItem)obj1, (IEnemy)obj2);
                else if (handlerDictionary.TryGetValue(obj2.GetType(), out var handle2))
                    handle2((IItem)obj2, (IEnemy)obj1);
            }
        }
        private readonly Dictionary<Type, ItemEnemyHandler> handlerDictionary = new Dictionary<Type, ItemEnemyHandler>
        {
            { typeof(FireBall) , FireBallVSEnemy}     
        };
        private static void FireBallVSEnemy(IItem fireBall, IEnemy enemy)
        {
            if (!((FireBall)fireBall).Explosion)
            {
                ((FireBall)fireBall).OnFireExplosion();
                enemy.Flipped();
                enemy.ObjState = ObjectState.NonCollidable;
            }
        }
    }
}
