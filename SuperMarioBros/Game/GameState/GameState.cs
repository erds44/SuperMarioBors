using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public abstract class GameState : IGameState
    {
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime game);

        public virtual void Die() { }
        public virtual void Pause() { }
        public virtual void TimeUp() { }
    }
}
