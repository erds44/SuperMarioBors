using SuperMarioBros.Enemy;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Objects.Enemy
{
    public class LeftMoving : IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly EnemyPhysics physics;
        public LeftMoving(IEnemy enemy, EnemyPhysics physics)
        {
            this.enemy = enemy;
            this.physics = physics;
            enemy.Sprite = SpriteFactory.CreateSprite(enemy.GetType().Name + GetType().Name);
        }

        public void ChangeDirection()
        {
            enemy.State = new RightMoving(enemy, physics);
        }

        public void Stomped()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}
