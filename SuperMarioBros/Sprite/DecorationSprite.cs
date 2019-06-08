using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using System.Collections.Generic;

namespace SuperMarioBros.Sprites
{
    class DecorationSprite : ISprite
    {
        private readonly ISprite sprite;
        public List<Color> SpriteColor { get; set; }
        public DecorationSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            sprite.SpriteColor = new List<Color> { Color.Green, Color.Black, Color.White };
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
