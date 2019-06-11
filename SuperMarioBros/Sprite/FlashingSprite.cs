using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using System.Collections.Generic;

namespace SuperMarioBros.Sprites
{
    class FlashingSprite : ISprite
    {
        private readonly ISprite sprite;
        public List<Color> SpriteColor { get; set; }
        public FlashingSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            sprite.SpriteColor = new List<Color> { Color.White, Color.White * 0.5f };
            sprite.Draw(spriteBatch, location);
            sprite.SpriteColor = new List<Color> { Color.White };
        }

        public int Width()
        {
            return sprite.Width();
        }

        public int Height()
        {
            return sprite.Height();
        }
    }
}
