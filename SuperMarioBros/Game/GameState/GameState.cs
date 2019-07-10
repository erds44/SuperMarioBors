using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

namespace SuperMarioBros.GameStates
{
    public class GameState : IGameState
    {
        private GraphicsDevice GraphicsDevice => game.GraphicsDevice;
        private readonly MarioGame game;
        private Color backGroundColor = Color.CornflowerBlue;
        
        public GameState(MarioGame game)
        {
            game.IsMouseVisible = false;
            this.game = game;
            if (game.ObjectsManager is null)
                game.InitializeGame();

            if (MediaPlayer.State == MediaState.Paused) MediaPlayer.Resume();
            else if (game.Player.Position.Y > 0) { MediaPlayer.Play(AudioFactory.Instance.CreateSong("overworld")); }
            else { MediaPlayer.Play(AudioFactory.Instance.CreateSong("underworld")); backGroundColor = Color.Black; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            GraphicsDevice.Clear(backGroundColor);
            game.ObjectsManager.Draw(spriteBatch);
            game.HeadsUps.Draw(spriteBatch, game.Camera.LeftBound, game.Camera.UpperBound);
            spriteBatch.End();
        }

        private int songUpdateDelay = 0;
        public void Update(GameTime gameTime)
        {
            MediaPlayer.Resume();
            if( ++songUpdateDelay> 10 &&  game.HeadsUps.Timer <= 100)
            {
                songUpdateDelay = 0;
                Song hurrySong = AudioFactory.Instance.CreateHurrySong(MediaPlayer.Queue.ActiveSong, out bool shouldNotChange);
                if (!shouldNotChange) { MediaPlayer.Play(hurrySong); }         
            }
            game.Controller.Update(gameTime);
            game.ObjectsManager.Update(gameTime);
            game.CollisionManager.Update();
            game.HeadsUps.Update(gameTime);
            game.Camera.Update();
        }
        public void Pause()
        {
            game.State = new PauseState(game);
        }
    }
}
