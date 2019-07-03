using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperMarioBros.GameStates
{
    public class MenuState : IGameState
    {
        private List<Buttons> buttons;
        private GraphicsDevice graphics;
        private ContentManager content;
        private Texture2D marioTitle;
        public MenuState(GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            graphics = graphicsDevice;
            content = contentManager;
            var itemFont = contentManager.Load<SpriteFont>("Font");
            marioTitle = contentManager.Load<Texture2D>("StartBackground");

            var startButton = new Buttons(itemFont, "New Game", new Vector2(MarioGame.Instance.WindowWidth / 2 - 60, MarioGame.Instance.WindowHeight / 2));
            startButton.Click += NewGameClick;

            var quitButton = new Buttons(itemFont, "Quit", new Vector2(MarioGame.Instance.WindowWidth / 2 - 60, MarioGame.Instance.WindowHeight / 2 + 60));
            quitButton.Click += QuitGameClick;

            buttons = new List<Buttons>
            {
                startButton,
                quitButton
            };
        }

        private void NewGameClick()
        {
            MarioGame.Instance.State = new PlayerStatusState(graphics, content);
        }
        private void QuitGameClick()
        {
            MarioGame.Instance.Exit();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphics.Clear(Color.CornflowerBlue);
            spriteBatch.Draw(marioTitle, Vector2.Zero, Color.White);
            foreach (var ele in buttons)
                ele.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var ele in buttons)
                ele.Update(gameTime);
        }

        public void Pause()
        {
            // Do Nothing
        }
    }
}

