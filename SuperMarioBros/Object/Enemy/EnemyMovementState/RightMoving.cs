using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Objects.Enemy
{
    public class RightMoving : IEnemyMovementState
    {
        private readonly IEnemy enemy;
        private EnemyPhysics physics;
        public RightMoving(IEnemy enemy, EnemyPhysics physics)
        {
            this.enemy = enemy;
            this.physics = physics;
            enemy.Sprite = SpriteFactory.CreateSprite(enemy.GetType().Name + GetType().Name);
        }

        public void ChangeDirection()
        {
            enemy.State = new LeftMoving(enemy, physics);
        }
    }
}
