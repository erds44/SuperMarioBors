using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Stats;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class ItemEnemyResponder : GeneralHandler, ICollisionResponder
    {
        private delegate void ItemEnemyHandler(IItem item, IEnemy enemy);
        private readonly Dictionary<Type, ItemEnemyHandler> handlerDictionary = new Dictionary<Type, ItemEnemyHandler>
        {
            { typeof(FireBall) , FireBallVSEnemy}
        };
        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            if (handlerDictionary.ContainsKey(mover.GetType()))
                handlerDictionary[mover.GetType()]((IItem)mover, (IEnemy)target);
            else if (handlerDictionary.ContainsKey(target.GetType()))
                handlerDictionary[target.GetType()]((IItem)target, (IEnemy)mover); //swap searching
        }
        private static void FireBallVSEnemy(IItem fireBall, IEnemy enemy)
        {
            ((FireBall)fireBall).FireExplosion();
            enemy.Flipped();
            enemy.ObjState = ObjectState.NonCollidable;
            StatsManager.Instance.Enemykilled(enemy.Position, enemy.Score);
        }
    }
}
