using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.GoombaStates;
using SuperMarioBros.Sprites;
using SuperMarioBros.Goombas.GoombaStates;

namespace SuperMarioBros.Goombas
{
    public class Goomba : IObject
    {
        private IGoombaState state;
        private Vector2 location;
        private ISprite sprite;
        public Goomba( Vector2 location)
        {
            state = new LeftMovingGoombaState(this);
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
