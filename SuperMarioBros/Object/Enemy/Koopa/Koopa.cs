using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.GoombaStates;
using SuperMarioBros.Koopas.KoopaStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Koopas
{
    public class Koopa : IObject
    {
        private IGoombaState state;
        private Vector2 location;
        private ISprite sprite; 
        public Koopa(Vector2 location)
        {
            state = new LeftMovingKoopaState(this);
            this.location = location;
        }
        public void ChangeDirection()
        {
            state.ChangeDirection();
        }

        public void BeStomped()
        {
            state.BeStomped();
        }

        public void BeFlipped()
        {
            state.BeFlipped();
        }
        public void Draw(SpriteBatch SpriteBatch)
        {
            sprite.Draw(SpriteBatch, location);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void ChangeSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }

        public void ChangeState(IGoombaState state)
        {
            this.state = state;
        }

        public Rectangle HitBox()
        {
            return new Rectangle((int)location.X, (int)(location.Y - sprite.Height()), sprite.Width(), sprite.Height());
        }
    }
}
