using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public interface IGameState :IUpdatable
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void Pause();
    }
}
