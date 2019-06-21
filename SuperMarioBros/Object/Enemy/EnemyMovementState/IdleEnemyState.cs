using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class IdleEnemyState : IEnemyMovementState
    {
        public IdleEnemyState(IEnemy enemy)
        {
            enemy.Sprite = SpriteFactory.CreateSprite(enemy.GetType().Name);
        }

        public void ChangeDirection()
        {
            // Do Nothing
        }
    }
}
