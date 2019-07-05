using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class TeleportingState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        public TeleportingState(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: MarioGame.Instance.marioCamera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            MarioGame.Instance.ObjectsManager.Draw(spriteBatch);
            MarioGame.Instance.HeadsUps.Draw(spriteBatch, MarioGame.Instance.Camera.LeftBound, MarioGame.Instance.Camera.UpperBound);
            spriteBatch.End();
        }

        public void Pause()
        {
            //Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            MarioGame.Instance.ObjectsManager.Mario.Update(gameTime);
            MarioGame.Instance.collisionManager.Update();
            if (MarioGame.Instance.FocusMario)
                MarioGame.Instance.marioCamera.Update();
        }
    }
}
