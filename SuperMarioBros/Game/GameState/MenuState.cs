using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperMarioBros.GameStates
{
    public class MenuState : IGameState
    {
        private readonly List<Buttons> buttons;
        private readonly GraphicsDevice graphics;
        private readonly Texture2D marioTitle;
        private readonly MarioGame game;
        public MenuState(MarioGame game)
        {
            this.game = game;
            graphics = game.GraphicsDevice;
            var itemFont = game.Content.Load<SpriteFont>("Font/MarioFontSize25");
            marioTitle = game.Content.Load<Texture2D>("StartBackground");

            var startButton = new Buttons(itemFont, "New Game", new Vector2(300, 240));
            startButton.Click += NewGameClick;

            var quitButton = new Buttons(itemFont, "Quit", new Vector2(300, 300));
            quitButton.Click += QuitGameClick;
            game.IsMouseVisible = true;
            buttons = new List<Buttons>
            {
                startButton,
                quitButton
            };
        }

        private void NewGameClick()
        {
            game.State = new ControllerState(game);
        }
        private void QuitGameClick()
        {
            game.Exit();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphics.Clear(Color.CornflowerBlue);
            spriteBatch.Draw(marioTitle, Vector2.Zero, Color.White);
            foreach (var ele in buttons)
                ele.Draw(spriteBatch);
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

