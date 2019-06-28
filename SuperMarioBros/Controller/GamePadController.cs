using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SuperMarioBros.Commands;
using System.Collections.Generic;

namespace SuperMarioBros.Controllers
{
    public class GamePadController : IController
    {

        private readonly Dictionary<GamePadButtons, ICommand> inputKeys;
        public GamePadController(params (GamePadButtons key, ICommand command)[] args)
        {
            inputKeys = new Dictionary<GamePadButtons, ICommand>();
            foreach ((GamePadButtons, ICommand) element in args)
            {
                inputKeys.Add(element.Item1, element.Item2);
            }
        }

        public void Update(GameTime gameTime)
        {
            GamePadButtons button = GamePad.GetState(PlayerIndex.One).Buttons;
            if (inputKeys.TryGetValue(button, out ICommand command))
            {
                command.Execute();
            }
        }

    }
}
