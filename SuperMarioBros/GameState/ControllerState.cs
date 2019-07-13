using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Utility;
using System.Collections.Generic;
using static SuperMarioBros.Utility.Locations;
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
            buttonFont = game.Content.Load<SpriteFont>(StringConsts.MarioFontForChoose);
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

        private void AddKeyBoardButton(List<Buttons> keyboardButtons)
        {
            var keyboardButton = new Buttons(buttonFont, StringConsts.KeyBoard, KeyboardButton);
            keyboardButton.Click += game.ChangeToPlayerStatusState;
            keyboardButtons.Add(keyboardButton);
        }

        private void AddGamePadButton(List<Buttons> gamepadButtons)
        {
            var GamePadButton = new Buttons(buttonFont, StringConsts.GamePad, GamepadButton);
            GamePadButton.Click += game.SetControllerAsGamePad;
            GamePadButton.Click += game.ChangeToPlayerStatusState;
            gamepadButtons.Add(GamePadButton);
        }
    }
}

