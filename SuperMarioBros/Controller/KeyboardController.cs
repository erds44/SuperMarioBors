using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBros.Controllers
{
    class KeyboardController : IController
    {
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
        public void Update()
        {
            Keys[] key = Keyboard.GetState().GetPressedKeys();
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
