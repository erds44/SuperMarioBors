using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Backgrounds
{
    public abstract class AbstractBackground : IStatic
    {
        private protected ISprite sprite;
        public Vector2 Position { get; set; }
        public bool IsInvalid { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
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
            return new Rectangle((int)Position.X,(int)Position.Y , 0, 0);
        }
        public void Destroy()
        {
            //Do nothing.
        }
        public void Destroy()
        {
            //Do nothing.
        }
    }
}
