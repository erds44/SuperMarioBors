using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SuperMarioBros.Commands;

namespace SuperMarioBros.Controllers
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    class GamePadController : IController
    {
        private readonly Dictionary<GamePadButtons, ICommand> inputKeys;
        public GamePadController(params (GamePadButtons key, ICommand command)[] args)
        {
            inputKeys = new Dictionary<GamePadButtons, ICommand>();
            foreach ((GamePadButtons,ICommand) element in args)
            {
                inputKeys.Add(element.Item1, element.Item2);
            }
        }


        public void Add(ICommand command)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            GamePadButtons button = GamePad.GetState(PlayerIndex.One).Buttons;
            if (inputKeys.TryGetValue(button, out ICommand command))
            {
                command.Execute();
            }
        }

    }
}
