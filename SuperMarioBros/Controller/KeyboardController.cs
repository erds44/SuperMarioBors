using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Managers;

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
        bool isLDown = false;
        public void Update()
        {
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            bool isPrevLDown = isLDown;
            isLDown = Keyboard.GetState().IsKeyDown(Keys.L);
            if (!(isLDown && isPrevLDown)&&isLDown) { //Debug use.
                var mario = ObjectsManager.Instance.Mario;
                Console.WriteLine(mario.Position);
                Console.WriteLine(mario.GetType());
                Console.WriteLine(mario.HealthState.GetType());
            };
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
