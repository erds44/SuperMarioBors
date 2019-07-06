using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public class PauseState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        private readonly MarioGame game;
        public PauseState(MarioGame game)
        {
            this.game = game;
            graphicsDevice = game.GraphicsDevice;
            MediaPlayer.Pause();
            AudioFactory.Instance.CreateSound("pause").Play();
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            game.ObjectsManager.Draw(spriteBatch);
            game.HeadsUps.Draw(spriteBatch, game.Camera.LeftBound, game.Camera.UpperBound);
            spriteBatch.End();
        }

        public void Pause()
        {
            game.State = new GameState(game);
        }

        public void Update(GameTime gameTime)
        {
            // Do Nothing
        }
    }
}
