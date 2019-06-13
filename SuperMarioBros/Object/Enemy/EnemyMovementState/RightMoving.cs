using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Objects.Enemy
{
    public class RightMoving : IEnemyMovementState
    {
        private readonly IEnemy enemy;
        public RightMoving(IEnemy enemy)
        {
            this.enemy = enemy;
            enemy.Sprite = SpriteFactory.CreateSprite(enemy.GetType().Name + GetType().Name);
        }

        public void ChangeDirection()
        {
            enemy.State = new LeftMoving(enemy);
        }
    }
}
