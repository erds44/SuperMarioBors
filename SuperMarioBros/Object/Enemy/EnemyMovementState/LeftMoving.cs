using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Objects.Enemy
{
    public class LeftMoving : IEnemyMovementState
    {
        private readonly IEnemy enemy;
        public LeftMoving(IEnemy enemy)
        {
            this.enemy = enemy;
            enemy.Sprite = SpriteFactory.CreateSprite(enemy.GetType().Name + GetType().Name);
        }

        public void ChangeDirection()
        {
            enemy.State = new RightMoving(enemy);
        }

    }
}
