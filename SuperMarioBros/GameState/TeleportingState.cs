using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public class TeleportingState : GameState
    {
        private readonly GraphicsDevice graphicsDevice;
        private readonly MarioGame game;
        private Color backGroundColor = Color.CornflowerBlue;
        private float teleportTimer = 2f;
        private Vector2 teleportPosition;
        public TeleportingState(MarioGame game, Vector2 Position)
        {
            game.DisableController();
            this.game = game;
            graphicsDevice = game.GraphicsDevice;
            MediaPlayer.Stop();
            AudioFactory.Instance.CreateSound("pipe").Play();
            if (game.Player.Position.Y < 0) backGroundColor = Color.Black;
            teleportPosition = Position;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            graphicsDevice.Clear(backGroundColor);
            game.ObjectsManager.Draw(spriteBatch);
            game.Hud.Draw(spriteBatch, game.CameraLeftBound, game.CameraUpperBound);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            teleportTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (teleportTimer <= 0) Teleport();
            game.Player.Update(gameTime);
            game.Camera.Update();
        }

        public override void TeleportPosition(Vector2 position)
        {
            teleportPosition = position;
        }

        private void Teleport()
        {
            if(teleportPosition.Y < 0)
                game.Camera.Update(teleportPosition + Utility.Locations.TeleportOffset);
            if(teleportPosition != Vector2.Zero)
                game.Player.Position = teleportPosition;
            game.Player.ResetVelocity();
            game.State = new PlayingState(game);
        }
    }
}
