using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Stats;
using SuperMarioBros.Utility;

namespace SuperMarioBros.GameStates
{
    public class PlayingState : GameState
    {
        private readonly MarioGame game;
        private Color backGroundColor = Color.CornflowerBlue;   
        public PlayingState(MarioGame game)
        {
            this.game = game;
            game.IsMouseVisible = false;
            if (game.IskeyboardController) game.InitializeKeyBoard();
            else game.InitializeGamePad();

            game.Player.DeathStateEvent += Die;
            StatsManager.Instance.TimeUpEvent += TimeUp;

            if (MediaPlayer.State == MediaState.Paused) MediaPlayer.Resume();
            else if (game.Player.Position.Y > 0)
            {
                MediaPlayer.Play(AudioFactory.Instance.CreateSong(StringConsts.OverWorld));
                game.SetFocus(game.Player);
            }
            else
            {
                MediaPlayer.Play(AudioFactory.Instance.CreateSong(StringConsts.UnderWorld));
                backGroundColor = Color.Black;
                game.SetFocus(null);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            game.GraphicsDevice.Clear(backGroundColor);
            game.ObjectsManager.Draw(spriteBatch);
            game.Hud.Draw(spriteBatch, game.CameraLeftBound, game.CameraUpperBound);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            MediaPlayer.Resume();
            game.Camera.Update();
            game.Controller.Update(gameTime);
            game.ObjectsManager.Update(gameTime);
            game.CollisionManager.Update();
            StatsManager.Instance.Update(gameTime);
        }
        public override void Pause()
        {
            game.State = new PauseState(game);
        }
        public override void Die(object sender, System.EventArgs e) { 
            game.Player.DestroyEvent -= Die;
            game.State = new PlayerDeadState(game);
        }
        public override void Reset(object sender, System.EventArgs e)
        {
            game.Player.DeathStateEvent += Die;
        }
        public override void TimeUp(object sender, System.EventArgs e)
        {
            game.Player.TimeOver();
            game.State = new PlayerDeadState(game);
        }

    }
}
