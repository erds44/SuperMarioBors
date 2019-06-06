using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Goombas
{
    public class StompedGoomba : IEnemy
    {
        private readonly IEnemy enemy;
        public StompedGoomba( IEnemy enemy)
        {
            enemy.ChangeState(new IdleEnemyState(enemy));
            this.enemy = enemy;
        }

        public void ChangeDirection()
        {
           // Do Nothing
        }

        public void BeStomped()
        {
            // Do Nothing
        }

        public void BeFlipped()
        {
            // Do Nothing
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            enemy.Draw(spriteBatch);
        }

        public void Update()
        {
            enemy.Update();
        }

        public void ChangeSprite(ISprite sprite)
        {
            // Do Nothing
        }


        public Rectangle HitBox()
        {
            return enemy.HitBox();
        }

        public void ChangeState(IEnemyMovementState enemyMovementState)
        {
            // Do Nothing
        }
    }
}
