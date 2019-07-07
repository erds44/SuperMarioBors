using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public interface IGameState :IUpdatable
    {
        void Draw(SpriteBatch spriteBatch);
        void Pause();
    }
}
