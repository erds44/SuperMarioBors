using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using System;

namespace SuperMarioBros.Classes.Object.ItemObject
{
    public abstract class AbstractItem : IObject
    {
        protected ISprite sprite;
        protected Vector2 location;
        public void ChangeSprite(ISprite sprite)
        {
            // Do Nothing
        }

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
