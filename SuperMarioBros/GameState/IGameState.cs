using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMarioBros.GameStates
{
    public interface IGameState :IUpdatable
    {
        void Draw(SpriteBatch spriteBatch);
        void Pause();
        void Die(object sender, System.EventArgs e);
        void TimeUp(object sender, System.EventArgs e);
        void TeleportPosition(Vector2 position);
        void Reset(object sender, System.EventArgs e);
    }
}
