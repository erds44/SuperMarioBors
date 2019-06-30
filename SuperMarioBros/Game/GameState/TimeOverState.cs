using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.GameStates
{
    public class TimeOverState : IGameState
    {
        /* TODO */
        private GraphicsDevice graphicsDevice;
        private SpriteFont spriteFont;
        private float timer = 2f;
        private ContentManager content;
        public TimeOverState(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
            spriteFont = content.Load<SpriteFont>("Font");
            this.content = content;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.DrawString(spriteFont, "TimeOver", new Vector2(400, 240), Color.Black);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                MarioGame.Instance.HeadsUps.ResetAll();
                MarioGame.Instance.ChangeState(new MenuState(graphicsDevice, content));
            }
        }
    }
}
