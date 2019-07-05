using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class FlagPoleState : IGameState
    {
        public bool UpdateHeadsUp { get; set; }
        private readonly MarioGame game;
        private GraphicsDevice graphicsDevice;
        public FlagPoleState(MarioGame game)
        {
            graphicsDevice = game.GraphicsDevice;
            UpdateHeadsUp = false;
            this.game = game;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.marioCamera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            game.ObjectsManager.Draw(spriteBatch);
            game.HeadsUps.Draw(spriteBatch, game.Camera.LeftBound, game.Camera.UpperBound);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            game.marioCamera.Update();
            game.ObjectsManager.Update(gameTime);
            game.collisionManager.Update();
            if(UpdateHeadsUp)
                game.HeadsUps.Update(gameTime);
        }

        public void Pause()
        {
            //Do Nothing
        }
    }
}
