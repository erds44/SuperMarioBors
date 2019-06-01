using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Controller
{
    class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> inputKeys;
        public KeyboardController(params (Keys key, ICommand command)[] args)
        {
            inputKeys = new Dictionary<Keys, ICommand>();
            foreach ((Keys, ICommand) element  in args)
            {
                inputKeys.Add(element.Item1, element.Item2);
            }
        }
        public void Add(Keys key, ICommand command)
        {
            inputKeys.Add(key, command);
        }
        public void Update()
        {
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            if (key.Count() > 0)
            {
                if (inputKeys.TryGetValue(key[0], out ICommand command))
                {
                    command.Execute();
                }
            }
        }
    }
}
