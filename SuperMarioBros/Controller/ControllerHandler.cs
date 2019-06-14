using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Commands;
using SuperMarioBros.Controllers;
using SuperMarioBros.Marios;
using System.Collections.Generic;

namespace SuperMarioBros
{
    public class ControllerHandler
    {
        private readonly List<IController> controllers;
        private readonly MarioGame game;
        private readonly IMario mario;
        private int moveFlags = 0b0000; //0b0001 = UP, 0b0010 = DOWN, 0b0100 = LEFT, 0b1000 = RIGHT.
        private int resetFlag = 0b0; //0b1 = reset;
        private int quitFlag = 0b0; //0b1 = quit;
        private ICommand idleCommand;
        public delegate void modifyFlag(int mask);
        public ControllerHandler(MarioGame marioGame, IMario marioObj)
        {
            game = marioGame;
            mario = marioObj;
        }
        private void KeyBinding()
        {
            
            controllers.Add(
                    new KeyboardController(
                    (Keys.Q, new QuitCommand(game)),
                    (Keys.A, new LeftCommand(mario)),
                    (Keys.S, new DownCommand(mario)),
                    (Keys.D, new RightCommand(mario)),
                    (Keys.W, new UpCommand(mario)),
                    (Keys.R, new ResetCommand(game)),
                    (Keys.Left, new LeftCommand(mario)),
                    (Keys.Down, new DownCommand(mario)),
                    (Keys.Right, new RightCommand(mario)),
                    (Keys.Up, new UpCommand(mario))
                ));

            idleCommand = new IdleCommand(mario);
        }
        public void Update()
        {
            
        }
    }
}
