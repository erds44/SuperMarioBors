using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperMarioBros.GameStates
{
    public class ChooseControllerState : GameState
    {
        private List<Buttons> buttons;
        private GraphicsDevice graphics;
        private SpriteFont buttonFont;
        private readonly MarioGame game;
        public ChooseControllerState(MarioGame game)
        {
            this.game = game;
            graphics = game.GraphicsDevice;
            buttonFont = game.Content.Load<SpriteFont>("Font/MarioFontSize25");
            game.IsMouseVisible = true;
            buttons = new List<Buttons>();
            AddKeyBoardButton(buttons);
            AddGamePadButton(buttons);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphics.Clear(Color.Black);
            foreach (var ele in buttons) ele.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var ele in buttons) ele.Update();
        }

        private void AddKeyBoardButton(List<Buttons> buttons)
        {
            var keyboardButton = new Buttons(buttonFont, "Keyboard", new Vector2(300, 140));
            keyboardButton.Click += game.ChangeToPlayerStatusState;
            buttons.Add(keyboardButton);
        }

        private void AddGamePadButton(List<Buttons> buttons)
        {
            var GamePadButton = new Buttons(buttonFont, "GamePad", new Vector2(300, 250));
            GamePadButton.Click += game.SetControllerAsGamePad;
            GamePadButton.Click += game.ChangeToPlayerStatusState;
            buttons.Add(GamePadButton);
        }
    }
}

