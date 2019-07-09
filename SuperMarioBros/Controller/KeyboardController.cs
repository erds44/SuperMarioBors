using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Commands;
using System.Collections.Generic;

namespace SuperMarioBros.Controllers
{
    class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> keyDownDictionary = new Dictionary<Keys, ICommand>();
        private readonly Dictionary<Keys, ICommand> keyUpDictionary = new Dictionary<Keys, ICommand>();
        private readonly List<Keys> checkKeyUplist = new List<Keys>();
        private readonly List<Keys> nonHoldableKeys = new List<Keys>();
        public bool IsPause { get; set; }
        public KeyboardController(params (Keys key, ICommand KeyDownCommand, ICommand KeyUpCommand , bool CanBeHeld)[] args)
        {
            foreach (var (key, downCommand, upCommand, canBeHeld) in args)
            {
                keyDownDictionary.Add(key, downCommand);
                keyUpDictionary.Add(key, upCommand);
                if (!canBeHeld)
                    nonHoldableKeys.Add(key);
            }
        }

        public void Update(GameTime gameTime)
        {
            Keys[] currentlyPressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys keyUp in keyUpDictionary.Keys)
            {
                if (checkKeyUplist.Contains(keyUp) && Keyboard.GetState().IsKeyUp(keyUp))
                {
                    keyUpDictionary[keyUp].Execute();
                    checkKeyUplist.Remove(keyUp);
                }

            }
            foreach (Keys keyDown in currentlyPressedKeys)
            {
                if (!nonHoldableKeys.Contains(keyDown) || !checkKeyUplist.Contains(keyDown))
                    if (keyDownDictionary.ContainsKey(keyDown))
                        keyDownDictionary[keyDown].Execute();                   
                if (!checkKeyUplist.Contains(keyDown))
                    checkKeyUplist.Add(keyDown);
            }
        }
    }
}
