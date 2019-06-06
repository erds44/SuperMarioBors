using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Koopas
{
    public class StompedKoopa :   IEnemy
    {
      //  private IEnemyMovementState state;
        private readonly IEnemy enemy;
       // private Point location;
        public StompedKoopa(IEnemy enemy)
        {
            enemy.ChangeState(new IdleEnemyState(enemy));
            this.enemy = enemy;
        }

        public void ChangeDirection()
        {
            // TO DO
        }

        public void ChangeSprite(ISprite sprite)
        {
            // Do Nothing
        }

        public void ChangeState(IEnemyMovementState enemyMovementState)
        {
            // TO DO
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemy.Draw(spriteBatch);
        }

        public Rectangle HitBox()
        {
            return enemy.HitBox();
        }

        public void Update()
        {
            // Do Nohitng
        }
    }
}
