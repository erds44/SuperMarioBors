using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class FlagPoleState : IGameState
    {
        public bool UpdateHeadsUp { get; set; }
        private GraphicsDevice graphicsDevice;
        public FlagPoleState(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
            UpdateHeadsUp = false;
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
            MarioGame.Instance.marioCamera.Update();
            MarioGame.Instance.ObjectsManager.Update(gameTime);
            MarioGame.Instance.collisionManager.Update();
            if(UpdateHeadsUp)
                MarioGame.Instance.HeadsUps.Update(gameTime);
        }
    }
}
