using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public class GameState : IGameState
    {
        private GraphicsDevice graphicsDevice => game.GraphicsDevice;
        private readonly MarioGame game;
        private int songUpdateDelay = 60;
        public GameState(MarioGame game)
        {
            this.game = game;
            if (game.ObjectsManager is null)
                game.InitializeGame();

            if (MediaPlayer.State == MediaState.Paused) MediaPlayer.Resume();
            else if (game.Player.Position.Y > 0) { MediaPlayer.Play(AudioFactory.Instance.CreateSong("overworld")); }
            else MediaPlayer.Play(AudioFactory.Instance.CreateSong("underworld"));
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
            if( ++songUpdateDelay>60 &&  game.HeadsUps.Timer <= 100)
            {
                songUpdateDelay -= 60;
                Song hurrySong = AudioFactory.Instance.CreateHurrySong(MediaPlayer.Queue.ActiveSong, out bool shouldNotChange);
                if (!shouldNotChange) { MediaPlayer.Play(hurrySong); }
            }
            game.controller.Update(gameTime);
            game.ObjectsManager.Update(gameTime);
            game.CollisionManager.Update();
            game.HeadsUps.Update(gameTime);
            if(game.FocusMario)
                game.Camera.Update();
        }
        public void Pause()
        {
            game.State = new PauseState(game);
        }
    }
}
