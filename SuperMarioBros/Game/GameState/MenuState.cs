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
            var itemTexture = contentManager.Load<Texture2D>("Button");
            var itemFont = contentManager.Load<SpriteFont>("Font");
            marioTitle = contentManager.Load<Texture2D>("Title");

            var startButton = new Buttons(itemTexture, itemFont)
            {
                Position = new Vector2(MarioGame.Instance.WindowWidth / 2 - 202, MarioGame.Instance.WindowHeight / 2 ),
                Text = "New Game",
            };
            startButton.Click += NewGameClick;

            var quitButton = new Buttons(itemTexture, itemFont)
            {
                Position = new Vector2(MarioGame.Instance.WindowWidth / 2 - 202, MarioGame.Instance.WindowHeight / 2 + 100),
                Text = "Quit",
            };
            quitButton.Click += QuitGameClick;

            buttons = new List<Buttons>
            {
                startButton,
                quitButton
            };
        }

        private void NewGameClick()
        {
            MarioGame.Instance.ChangeState(new GameState(graphics, content));
        }
        private void QuitGameClick()
        {
            MarioGame.Instance.Exit();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphics.Clear(Color.CornflowerBlue);
            spriteBatch.Draw(marioTitle, new Vector2(200, 10), Color.White);
            foreach (var ele in buttons)
                ele.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var ele in buttons)
                ele.Update(gameTime);
        }

        public void InitializeGame()
        {
           // Do Nothing
        }
    }
}

