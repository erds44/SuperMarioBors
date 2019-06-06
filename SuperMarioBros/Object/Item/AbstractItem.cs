using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public abstract class AbstractItem
    {
        protected ISprite sprite;
        protected Vector2 location;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public Rectangle HitBox()
        {
            return new Rectangle((int)location.X, (int)(location.Y - sprite.Height()), sprite.Width(), sprite.Height());
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
