using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBros.Controllers
{
    class KeyboardController : IController
    {
        /*        private readonly Dictionary<Keys, ICommand> inputKeys;*/
        private readonly Dictionary<Keys, int> inputKeys;
        private readonly ControllerMessager messager;
        public KeyboardController(ControllerMessager controllerMessager, params(Keys key, int command)[] args)
        {
            messager = controllerMessager;
            inputKeys = new Dictionary<Keys, int>();
            foreach ((Keys, int) element in args)
            {
                inputKeys.Add(element.Item1, element.Item2);
            }
        }
/*        private ICommand IdleCommand;*/
/*        public KeyboardController(params (Keys key, ICommand command)[] args)
        {
            inputKeys = new Dictionary<Keys, ICommand>();
            foreach ((Keys, ICommand) element  in args)
            {
                inputKeys.Add(element.Item1, element.Item2);
            }
        }*/
/*        public void SetIdle(ICommand command)
        {
            IdleCommand = command;
        }*/
        public void Update()
        {
            /* The idle command is called when player release any movement keys for Mario*/
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            if (key.Count() > 0)
            {
                foreach(Keys keyPressed in key)
                {
                    if (inputKeys.TryGetValue(keyPressed, out int command))
                    {
                        messager.ChangeFlags(command);
                    }
                }
            }
        }
    }
}
