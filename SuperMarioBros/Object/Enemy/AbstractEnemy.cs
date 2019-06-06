using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Goombas
{
    public abstract class AbstractEnemy : IEnemy
    {
        protected IEnemyMovementState state;
        protected Point location;
        protected ISprite sprite;

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void ChangeSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }

        public void ChangeState(IEnemyMovementState state)
        {
            this.state = state;
        }

        public Rectangle HitBox()
        {
            return new Rectangle((int)location.X, (int)(location.Y - sprite.Height()), sprite.Width(), sprite.Height());
        }
    }
}
