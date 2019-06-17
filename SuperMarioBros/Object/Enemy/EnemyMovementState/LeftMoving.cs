using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Objects.Enemy
{
    public class LeftMoving : IEnemyMovementState
    {
        private readonly IEnemy enemy;
        private ObjectPhysics physics;
        public LeftMoving(IEnemy enemy, ObjectPhysics physics)
        {
            this.enemy = enemy;
            this.physics = physics;
            enemy.Sprite = SpriteFactory.CreateSprite(enemy.GetType().Name + GetType().Name);
        }

        public void ChangeDirection()
        {
            enemy.State = new RightMoving(enemy, physics);
        }

    }
}
