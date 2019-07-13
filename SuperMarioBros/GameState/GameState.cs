using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMarioBros.GameStates
{
    public abstract class GameState : IGameState
    {
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime game);

        public virtual void Die(object sender, System.EventArgs e) { }
        public virtual void Pause() { }
        public virtual void TimeUp(object sender, System.EventArgs e) { }
        public virtual void TeleportPosition(Vector2 position) { }
        public virtual void Reset(object sender, System.EventArgs e) { }
    }
}
