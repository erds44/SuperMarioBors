using SuperMarioBros.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class IdleEnemyState : IEnemyState
    {
        public IdleEnemyState(IEnemy enemy)
        {
            enemy.Sprite = SpriteFactory.CreateSprite(enemy.GetType().Name);
        }

        public void ChangeDirection()
        {
            // Do Nothing
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
