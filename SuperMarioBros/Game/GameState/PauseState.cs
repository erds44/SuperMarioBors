using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBros.GameStates
{
    public class PauseState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        public PauseState(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: MarioGame.Instance.marioCamera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            MarioGame.Instance.ObjectsManager.Draw(spriteBatch);
            MarioGame.Instance.HeadsUps.Draw(spriteBatch, MarioGame.Instance.Camera.LeftBound);
            spriteBatch.End();
        }

        public void Pause()
        {
            MarioGame.Instance.State = new GameState(graphicsDevice);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
