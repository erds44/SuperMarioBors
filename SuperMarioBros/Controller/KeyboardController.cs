using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Managers;

namespace SuperMarioBros.Controllers
{
    class KeyboardController : IController
    {
        private readonly Dictionary<Keys, int> keyDownDictionary;
        private readonly Dictionary<Keys, int> keyUpDictionary = new Dictionary<Keys, int>
        {
            { Keys.Up, ControllerMessager.KEYUPUPMOVE },
            { Keys.X, ControllerMessager.KEYUPPOWER }
        };
        private List<Keys> checkKeyUplist = new List<Keys>();
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
        public void Update()
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
                if (Keyboard.GetState().IsKeyDown(keyPressed))
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
}
