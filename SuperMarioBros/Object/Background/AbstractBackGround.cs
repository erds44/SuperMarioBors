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
        /* For background, We treate the hit box is empty
         * We can later make backgournd as non-cllideable object 
         * such that it does not have bitbox method at all
         */
        public Rectangle HitBox()
        {
            return new Rectangle(location.X,location.Y , 0, 0);
        }
        public void Destroy()
        {
            //Do nothing.
        }
    }
}
