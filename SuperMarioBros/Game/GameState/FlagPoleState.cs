using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public class FlagPoleState : IGameState
    {
        public bool UpdateHeadsUp { get; set; }
        private readonly MarioGame game;
        private readonly GraphicsDevice graphicsDevice;
        public FlagPoleState(MarioGame game)
        {
            graphicsDevice = game.GraphicsDevice;
            UpdateHeadsUp = false;
            this.game = game;
            MediaPlayer.Stop();
            AudioFactory.Instance.CreateSound("flagpole").Play();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            game.ObjectsManager.Draw(spriteBatch);
            game.HeadsUps.Draw(spriteBatch, game.Camera.LeftBound, game.Camera.UpperBound);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            game.Camera.Update();
            game.ObjectsManager.Update(gameTime);
            game.CollisionManager.Update();
            if(UpdateHeadsUp)
                game.HeadsUps.Update(gameTime);
        }

        public void Pause()
        {
            //Do Nothing
        }
    }
}
