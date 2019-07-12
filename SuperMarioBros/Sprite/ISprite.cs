using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Sprites
{
    public interface ISprite : IUpdatable
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location, SpriteEffects spriteEffects = SpriteEffects.None, float scale = SpriteConsts.DefaultScale);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteColor, SpriteEffects spriteEffects = SpriteEffects.None, float scale = SpriteConsts.DefaultScale);

        void SetLayer(float layer);
    }
}
