using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMarioBros.GameStates
{
    public interface IGameState :IUpdatable
    {
        void Draw(SpriteBatch spriteBatch);
        void Pause();
        void Die();
        void TimeUp();
        void TeleportPosition(Vector2 position);
        void Reset();
    }
}
