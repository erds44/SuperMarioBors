using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public abstract class AbstractItem
    {
        private protected ISprite sprite;
        public Vector2 Position { get; set; }
        public bool IsInvalid { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }
    }
}
