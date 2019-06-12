using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public abstract class AbstractItem
    {
        private protected ISprite sprite;
        private protected Point location;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle(location.X, location.Y - size.Y, size.X, size.Y);
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
