using SuperMarioBros.Commands;
using SuperMarioBros.Controllers;
using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Controllers
{
    public class ControllerMessager : IUpdate
    {
        private int flags = 0b000000;
        public const int UPMOVE = 0b000001, DOWNMOVE = 0b000010, LEFTMOVE = 0b000100, RIGHTMOVE = 0b001000, RESETGAME = 0b010000, QUITGAME = 0b100000;
        private readonly MarioGame marioGame;
        private readonly IMario marioPlayer;
        private readonly List<IController> controllers;
        private readonly Dictionary<int, Type> gameCommand = new Dictionary<int, Type>{
            { QUITGAME, typeof(QuitCommand) },
            { RESETGAME, typeof(ResetCommand) }
        };
        private readonly Dictionary<int, Type> moveCommand = new Dictionary<int, Type> {
            { LEFTMOVE, typeof(LeftCommand) },
            { RIGHTMOVE, typeof(RightCommand) },
            { UPMOVE, typeof(UpCommand) },
            { DOWNMOVE, typeof(DownCommand) }
        };
        public ControllerMessager(MarioGame game, IMario mario)
        {
            marioGame = game;
            marioPlayer = mario;
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
            if(flags == 0)
            {
                new IdleCommand(marioPlayer).Execute();
            }
            foreach(KeyValuePair<int, Type> element in gameCommand)
            {
                if((flags & element.Key) != 0) { ((ICommand)Activator.CreateInstance(element.Value, marioGame)).Execute(); }
            }
            foreach(KeyValuePair<int, Type> element in moveCommand)
            {
                if((flags & element.Key) != 0) { ((ICommand)Activator.CreateInstance(element.Value, marioPlayer)).Execute(); }
            }
            flags = 0b000000; //Reset flags.
        }
        public void ChangeFlags(int command)
        {
            flags |= command; //Bitwise Update.
        }
    }
}
