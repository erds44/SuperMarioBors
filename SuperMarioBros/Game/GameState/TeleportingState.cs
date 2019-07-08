using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public class TeleportingState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        private readonly MarioGame game;
        public TeleportingState(MarioGame game)
        {
            this.game = game;
            graphicsDevice = game.GraphicsDevice;
            MediaPlayer.Stop();
            AudioFactory.Instance.CreateSound("pipe").Play();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            game.ObjectsManager.Draw(spriteBatch);
            game.HeadsUps.Draw(spriteBatch, game.Camera.LeftBound, game.Camera.UpperBound);
            spriteBatch.End();
        }

        public void Pause()
        {
            //Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            game.ObjectsManager.Mario.Update(gameTime);
            game.CollisionManager.Update();
            if (game.FocusMario)
                game.Camera.Update();
        }
    }
}
