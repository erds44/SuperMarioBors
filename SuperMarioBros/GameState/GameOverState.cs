using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;

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
            spriteFont = game.Content.Load<SpriteFont>("Font/MarioFont");
            MediaPlayer.Stop();
            MediaPlayer.Play(AudioFactory.Instance.CreateSong("gameover"));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(spriteFont, "GameOver", Utility.Locations.GameoverString, Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0) game.State = new MenuState(game);
        }
    }
}
