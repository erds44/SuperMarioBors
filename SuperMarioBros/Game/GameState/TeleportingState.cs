using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public class TeleportingState : IGameState
    {
        private readonly GraphicsDevice graphicsDevice;
        private readonly MarioGame game;
        private Color backGroundColor = Color.CornflowerBlue;
        public TeleportingState(MarioGame game)
        {
            game.DisableController();
            this.game = game;
            graphicsDevice = game.GraphicsDevice;
            MediaPlayer.Stop();
            AudioFactory.Instance.CreateSound("pipe").Play();
            if (game.Player.Position.Y < 0) backGroundColor = Color.Black;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            graphicsDevice.Clear(backGroundColor);
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
            //if (game.FocusMario)
                game.Camera.Update();
        }
    }
}
