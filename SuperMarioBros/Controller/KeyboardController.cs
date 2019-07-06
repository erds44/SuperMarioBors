using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBros.Controllers
{
    class KeyboardController : IController
    {
        private readonly Dictionary<Keys, int> keyDownDictionary;
        private readonly Dictionary<Keys, int> keyUpDictionary = new Dictionary<Keys, int>
        {
            { Keys.Up, ControllerMessager.KEYUPUPMOVE },
            { Keys.W, ControllerMessager.KEYUPUPMOVE },
            { Keys.Z, ControllerMessager.KEYUPUPMOVE },
            { Keys.X, ControllerMessager.KEYUPPOWER },
            { Keys.Down, ControllerMessager.KEYDOWNUP },
            { Keys.S, ControllerMessager.KEYDOWNUP }
        };
        private readonly List<Keys> checkKeyUplist = new List<Keys>();
        private readonly ControllerMessager messager;
        public KeyboardController(ControllerMessager controllerMessager, params (Keys key, int command)[] args)
        {
            messager = controllerMessager;
            keyDownDictionary = new Dictionary<Keys, int>();
            foreach ((Keys, int) element in args)
            {
                keyDownDictionary.Add(element.Item1, element.Item2);
            }
        }
        public void Update(GameTime gameTime)
        {
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            foreach (Keys keyPressed in checkKeyUplist)
            {
                if (Keyboard.GetState().IsKeyUp(keyPressed))
                {
                    if (keyUpDictionary.TryGetValue(keyPressed, out int command))
                        messager.ChangeFlags(command);
                }
            }
            checkKeyUplist.Clear();
            foreach (Keys keyPressed in key)
            {
                if (keyDownDictionary.TryGetValue(keyPressed, out int command))
                {
                    messager.ChangeFlags(command);
                    if (keyUpDictionary.ContainsKey(keyPressed))
                    {
                        checkKeyUplist.Add(keyPressed);
                    }
                }
            }
        }
    }
}
