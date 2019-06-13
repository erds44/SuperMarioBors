using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Commands;

namespace SuperMarioBros.Controllers
{
    class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> inputKeys;
        private ICommand IdleCommand;
        public KeyboardController(params (Keys key, ICommand command)[] args)
        {
            inputKeys = new Dictionary<Keys, ICommand>();
            foreach ((Keys, ICommand) element  in args)
            {
                inputKeys.Add(element.Item1, element.Item2);
            }
        }
        public void Add(ICommand command)
        {
            IdleCommand = command;
        }
        public void Update()
        {
            /* The idle command is called when player release any movement keys for Mario*/
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            if (key.Count() > 0)
            {
                foreach(Keys keyPressed in key)
                {
                    if (inputKeys.TryGetValue(keyPressed, out ICommand command))
                    {
                        command.Execute();
                    }
                    else
                    {
                        IdleCommand.Execute();
                    }
                }
            }
            else
            {
                IdleCommand.Execute();
            }
        }
    }
}
