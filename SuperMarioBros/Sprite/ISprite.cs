using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Sprites
{
    public interface ISprite : IUpdatable
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location, SpriteEffects spriteEffects = SpriteEffects.None, float scale = 1f);
        void SetColor(Collection<Color> colors);
        void SetLayer(float layer);
    }
}
