using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Stats;
using SuperMarioBros.Utility;
using System.Collections.Generic;

namespace SuperMarioBros.GameStates
{
    public class MenuState : GameState
    {
        private readonly List<Buttons> buttons;
        private readonly GraphicsDevice graphics;
        private readonly Texture2D background;
        private readonly MarioGame game;
        private readonly SpriteFont spriteFont;
        public MenuState(MarioGame game)
        {
            this.game = game;
            game.IsMouseVisible = true;
            graphics = game.GraphicsDevice;
            spriteFont = game.Content.Load<SpriteFont>(StringConsts.MarioFontForChoose);
            background = game.Content.Load<Texture2D>(StringConsts.StartBackground);
            buttons = new List<Buttons>();
            StatsManager.Instance.Reset();
            AddNewGameButton(buttons);
            AddQuitGameButton(buttons);
        }
        private void AddNewGameButton(List<Buttons> newGameButton)
        {
            var startButton = new Buttons(spriteFont, StringConsts.NewGame, Locations.NewgameButton);
            startButton.Click += NewGameClick;
            newGameButton.Add(startButton);
        }

        private void NewGameClick(object sender, System.EventArgs e)
        {
            game.State = new ChooseControllerState(game);
        }

        private void AddQuitGameButton(List<Buttons> quitGameButton)
        {
            var quitButton = new Buttons(spriteFont, StringConsts.Quit, Locations.QuitButton);
            quitButton.Click += QuitGameClick;
            quitGameButton.Add(quitButton);
        }

        private void QuitGameClick(object sender, System.EventArgs e)
        {
            game.Exit();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphics.Clear(Color.CornflowerBlue);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            foreach (var ele in buttons) ele.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var ele in buttons) ele.Update();
        }
    }
}

