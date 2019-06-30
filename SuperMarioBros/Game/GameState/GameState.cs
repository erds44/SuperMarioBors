using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class GameState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        //private ContentManager contentManager;
        public GameState(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            if (MarioGame.Instance.ObjectsManager is null)
                MarioGame.Instance.InitializeGame();
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: MarioGame.Instance.marioCamera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            MarioGame.Instance.ObjectsManager.Draw(spriteBatch);
            MarioGame.Instance.HeadsUps.Draw(spriteBatch, MarioGame.Instance.Camera.LeftBound);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            MarioGame.Instance.controller.Update(gameTime);
            MarioGame.Instance.marioCamera.Update();
            MarioGame.Instance.ObjectsManager.Update(gameTime);
            MarioGame.Instance.collisionManager.Update();
            MarioGame.Instance.HeadsUps.Update(gameTime);
        }
    }
}
