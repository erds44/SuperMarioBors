using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class GameState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        private readonly MarioGame game;
        public GameState(MarioGame game)
        {
            this.game = game;
            graphicsDevice = game.GraphicsDevice;
            if (game.ObjectsManager is null)
                game.InitializeGame();
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
            game.controller.Update(gameTime);
            game.ObjectsManager.Update(gameTime);
            game.collisionManager.Update();
            game.HeadsUps.Update(gameTime);
            if(game.FocusMario)
                game.marioCamera.Update();
        }
        public void Pause()
        {
            game.State = new PauseState(game);
        }
    }
}
