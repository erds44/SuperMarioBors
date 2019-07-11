using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperMarioBros.GameStates
{
    public class ControllerState : IGameState
    {
        private List<Buttons> buttons;
        private GraphicsDevice graphics;
        private readonly MarioGame game;
        public ControllerState(MarioGame game)
        {
            this.game = game;
            graphics = game.GraphicsDevice;
            var itemFont = game.Content.Load<SpriteFont>("Font/MarioFontSize25");

            var keyboardButton = new Buttons(itemFont, "Keyboard", new Vector2(300, 140));
            keyboardButton.Click += game.ChangeToPlayerStatusState;

           var GamePadButton = new Buttons(itemFont, "GamePad", new Vector2(300, 250));
            GamePadButton.Click += game.SetControllerAsGamePad;
            GamePadButton.Click += game.ChangeToPlayerStatusState;
            game.IsMouseVisible = true;
            buttons = new List<Buttons>
            {
                keyboardButton,
                GamePadButton
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphics.Clear(Color.Black);
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

