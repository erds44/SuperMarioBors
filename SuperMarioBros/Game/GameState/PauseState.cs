using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Commands;
using SuperMarioBros.Controllers;
using Buttons = Microsoft.Xna.Framework.Input.Buttons;

namespace SuperMarioBros.GameStates
{
    public class PauseState : IGameState
    {
        private readonly GraphicsDevice graphicsDevice;
        private readonly MarioGame game;
        public PauseState(MarioGame game)
        {
            this.game = game;
            graphicsDevice = game.GraphicsDevice;
            if (game.IskeyboardController)
                game.Controller = new KeyboardController((Keys.O, new PauseCommand(game), new EmptyCommand(), false));
            else
                game.Controller = new JoyStickController(game.Player, (Microsoft.Xna.Framework.Input.Buttons.LeftShoulder, new PauseCommand(game), new EmptyCommand(), false));
            MediaPlayer.Pause();
            AudioFactory.Instance.CreateSound("pause").Play();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: game.Camera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            game.ObjectsManager.Draw(spriteBatch);
            game.HeadsUps.Draw(spriteBatch, game.Camera.LeftBound, game.Camera.UpperBound);
            spriteBatch.End();
        }

        public void Pause()
        {
            game.State = new GameState(game);
        }

        public void Update(GameTime gameTime)
        {
            game.Controller.Update(gameTime);
        }
    }
}
