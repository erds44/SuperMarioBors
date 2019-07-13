using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using static SuperMarioBros.Utility.StringConsts;
using static SuperMarioBros.Utility.GeneralConstants;
using static SuperMarioBros.Utility.Timers;

namespace SuperMarioBros.GameStates
{
    public class GameOverState : GameState
    {
        private GraphicsDevice graphicsDevice;
        private readonly SpriteFont spriteFont;
        private float timer = 2f;
        private readonly MarioGame game;
        public GameOverState(MarioGame game)
        {
            this.game = game;
            this.graphicsDevice = game.GraphicsDevice;
            spriteFont = game.Content.Load<SpriteFont>(Font);
            MediaPlayer.Stop();
            MediaPlayer.Play(AudioFactory.Instance.CreateSong(Gameover));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(spriteFont, GameOverString, Utility.Locations.GameoverString, Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= InitialTime) game.State = new MenuState(game);
        }
    }
}
