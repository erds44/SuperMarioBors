using System;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class LeftMovingEnemyState : IEnemyMovementState
    {
        private readonly IEnemy enemy;
        public LeftMovingEnemyState(IEnemy enemy)
        {
            this.enemy = enemy;
            enemy.ChangeSprite(SpriteFactory.CreateSprite(enemy.GetType().Name + "LeftMoving"));
        }

        public void ChangeDirection()
        {
            enemy.ChangeState(new RightMovingEnemyState(enemy));

        }

    }
}
