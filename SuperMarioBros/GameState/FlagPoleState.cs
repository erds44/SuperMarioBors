using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Stats;

namespace SuperMarioBros.GameStates
{
    public class FlagPoleState : GameState
    {
        private readonly MarioGame game;
        private readonly GraphicsDevice graphicsDevice;
        private bool isClearingScore = false;
        public FlagPoleState(MarioGame game)
        {
            graphicsDevice = game.GraphicsDevice;
            this.game = game;
            game.Player.ClearingScoresEvent += ClearScore;
            MediaPlayer.Stop();
            AudioFactory.Instance.CreateSound("flagpole").Play();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            game.ObjectsManager.Draw(spriteBatch);
            game.Hud.Draw(spriteBatch, game.CameraLeftBound, game.CameraUpperBound);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            game.Camera.Update();
            game.ObjectsManager.Update(gameTime);
            game.CollisionManager.Update();
            if(isClearingScore) StatsManager.Instance.CollectRemainingTime();
            if(StatsManager.Instance.Time == 0) isClearingScore = false;
        }
        
        private void ClearScore()
        {
            isClearingScore = true;
        }
    }
}
