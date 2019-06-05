using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
namespace SuperMarioBros.Sprites
{
    public interface ISprite : IUpdate
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        int Width();
        int Height();
    }
}
