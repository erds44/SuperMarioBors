using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class PlayerStatusState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        private SpriteFont spriteFont;
        private float timer = 2f;
        public PlayerStatusState(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
           spriteFont = content.Load<SpriteFont>("Font");
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.DrawString(spriteFont, "Number of Lives X " + MarioGame.Instance.HeadsUps.Lives, new Vector2(300, 240), Color.Black);
            spriteBatch.End();
        }

        public void Pause()
        {
           // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                MarioGame.Instance.State = new GameState(graphicsDevice);
            }                
        }
    }
}
