using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Sprites
{
    public class DecorationSprite : ISprite
    {
        private readonly ISprite sprite;
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
            sprite.SetColor( new Collection<Color> { Color.Green, Color.Black, Color.White });
            sprite.Draw(spriteBatch, location);
            sprite.SetColor(new Collection<Color> { Color.White });
        }

        public void SetColor(Collection<Color> colors)
        {
           // Do Nothing
        }
    }
}
