using System;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class RightMovingEnemyState : IEnemyMovementState
    {
        private readonly IEnemy enemy;
        public RightMovingEnemyState(IEnemy enemy)
        {
            this.enemy = enemy;
            enemy.ChangeSprite(SpriteFactory.CreateSprite(enemy.GetType().Name + "RightMoving"));
        }

        public void ChangeDirection()
        {
            enemy.ChangeState(new LeftMovingEnemyState(enemy));
            // More to do
        }
    }
}
