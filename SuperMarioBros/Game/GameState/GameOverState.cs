using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class GameOverState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        private SpriteFont spriteFont;
        private float timer = 2f;
        private readonly MarioGame game;
        public GameOverState(MarioGame game)
        {
            this.game = game;
            this.graphicsDevice = game.GraphicsDevice;
            spriteFont = game.Content.Load<SpriteFont>("Font/MarioFont");
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(spriteFont, "GameOver", new Vector2(350, 240), Color.White);
            spriteBatch.End();
        }

        public void Pause()
        {
            //Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                game.HeadsUps.ResetAll();
                game.State = new MenuState(game);
            }
        }
    }
}
