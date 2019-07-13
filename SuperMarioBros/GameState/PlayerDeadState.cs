using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Stats;
using System;

namespace SuperMarioBros.GameStates
{
    public class PlayerDeadState : GameState
    {
        private readonly MarioGame game;
        private Color backGroundColor = Color.CornflowerBlue;   
        public PlayerDeadState(MarioGame game)
        {
            this.game = game;
            game.Player.DestroyEvent += Die;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            game.GraphicsDevice.Clear(backGroundColor);
            game.ObjectsManager.Draw(spriteBatch);
            game.Hud.Draw(spriteBatch, game.CameraLeftBound, game.CameraUpperBound);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            game.ObjectsManager.Update(gameTime);
            game.CollisionManager.Update();
        }
        public override void Die()
        {
            game.ResetGame();
            if (StatsManager.Instance.Life == 0) game.State = new GameOverState(game);
            else game.State = new PlayerStatusState(game);
        }

    }
}
