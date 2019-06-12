using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Backgrounds
{
    public abstract class AbstractBackground : IObject
    {
        private protected ISprite sprite;
        private protected Point location;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update()
        {
            sprite.Update();
        }

        public Rectangle HitBox()
        {
            return new Rectangle(location.X,location.Y , 0, 0);
        }
    }
}
