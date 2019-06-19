using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Sprites
{
    public class FlashingSprite : ISprite
    {
        private readonly ISprite sprite;
        public FlashingSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.SetColor( new Collection<Color> { Color.White, Color.White * 0.5f });
            sprite.Draw(spriteBatch, location);
            sprite.SetColor(new Collection<Color> { Color.White });
        }
        public void SetColor(Collection<Color> colors)
        {
            // Do Nothing
        }
    }
}
