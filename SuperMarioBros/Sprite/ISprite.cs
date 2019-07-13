using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Sprites
{
    public interface ISprite : IUpdatable
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location, SpriteEffects spriteEffects, float scale);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteColor, SpriteEffects spriteEffects, float scale);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteColor);

        void SetLayer(float layer);
    }
}
