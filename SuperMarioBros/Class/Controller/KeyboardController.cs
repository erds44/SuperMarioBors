using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using SuperMarioBros.Class.Command;

namespace SuperMarioBros.Class.Controller
{
    class KeyboardController : IController
    {
        private IReceiver receiver;
        private ICommand defaultCommand;
        private Dictionary<Keys, ICommand> inputKeys;
        public KeyboardController(MarioGame game)
        {
            inputKeys = new Dictionary<Keys, ICommand>();
            receiver = new InputAction(game);
            BindKeys();
        }

        private void BindKeys()
        {
            inputKeys.Add(Keys.Q, new Quit(receiver));
            inputKeys.Add(Keys.A, new LeftCommand(receiver));
            inputKeys.Add(Keys.D, new RightCommand(receiver));
            inputKeys.Add(Keys.W, new UpCommand(receiver));
            inputKeys.Add(Keys.S, new DownCommand(receiver));
        }
        public void Update()
        {
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            if (key.Count() > 0)
            {
                ICommand command;
                if (inputKeys.TryGetValue(key[0], out command))
                {
                    command.Execute();
                }
            }

        }
    }
}
