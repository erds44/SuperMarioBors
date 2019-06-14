using SuperMarioBros.Commands;
using SuperMarioBros.Controllers;
using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Controller
{
    public class ControllerMessager : IUpdate
    {
        private int flags = 0b000000;
        public const int NOMOVE = 0b000000, UPMOVE = 0b000001, DOWNMOVE = 0b000010, LEFTMOVE = 0b000100, RIGHTMOVE = 0b001000, RESETGAME = 0b010000, QUITGAME = 0b100000;
        private readonly MarioGame marioGame;
        private readonly IMario marioPlayer;
        private List<IController> controllers;
        private readonly ICommand idle;
        public ControllerMessager(MarioGame game, IMario mario, ICommand idleCommand)
        {
            marioGame = game;
            marioPlayer = mario;
            idle = idleCommand;
            controllers = new List<IController>();
        }
        public void AddController(IController controller)
        {
            controllers.Add(controller);
        }
        public void Update()
        {
            foreach(IController controller in controllers)
            {
                controller.Update();
            }

            if ((flags | NOMOVE) == 0)
            {
                new IdleCommand(marioPlayer).Execute();
                return;
            }

            if ((flags & QUITGAME) != 0) {
                new QuitCommand(marioGame).Execute();
                return;
            } 

            if((flags & RESETGAME) != 0)
            {
                new ResetCommand(marioGame).Execute();
                return;
            }
            
            if((flags & UPMOVE) != 0)
            {
                new UpCommand(marioPlayer).Execute();
            }
            if((flags & DOWNMOVE) != 0)
            {
                new DownCommand(marioPlayer).Execute();
            }
            if((flags & LEFTMOVE) != 0)
            {
                new LeftCommand(marioPlayer).Execute();
            }
            if((flags & RIGHTMOVE) != 0)
            {
                new RightCommand(marioPlayer).Execute();
            }
            flags = flags & NOMOVE; //Reset flags.
        }
        public void ChangeFlags(int command)
        {
            flags = flags | command; //Bitwise Update.
        }
    }
}
