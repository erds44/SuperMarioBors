using SuperMarioBros.Commands;
using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Controllers
{
    public class ControllerMessager : IUpdate
    {
        private int flags = 0b00000000;
        public const int UPMOVE = 0b00000001, DOWNMOVE = 0b00000010, LEFTMOVE = 0b00000100, RIGHTMOVE = 0b00001000, RESETGAME = 0b00010000, QUITGAME = 0b00100000, POWER = 0b01000000, KEYUPUPMOVE = 0b10000000;
        private readonly MarioGame marioGame;
        private readonly IMario marioPlayer;
        private readonly List<IController> controllers;
        private readonly Dictionary<int, Type> gameCommand = new Dictionary<int, Type>{
            { QUITGAME, typeof(QuitCommand) },
            { RESETGAME, typeof(ResetCommand) }
        };
        private readonly Dictionary<int, Type> actionCommand = new Dictionary<int, Type> {
            { LEFTMOVE, typeof(LeftCommand) },
            { RIGHTMOVE, typeof(RightCommand) },
            { UPMOVE, typeof(UpCommand) },
            { DOWNMOVE, typeof(DownCommand) },
            { POWER, typeof(PowerCommand) },
            { KEYUPUPMOVE, typeof(KeyUpUpCommand) },
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
            marioPlayer.PowerFlag = ((flags & POWER) != 0);
            foreach(KeyValuePair<int, Type> element in gameCommand)
            {
                if((flags & element.Key) != 0) { ((ICommand)Activator.CreateInstance(element.Value, marioGame)).Execute(); }
            }
            foreach(KeyValuePair<int, Type> element in actionCommand)
            {
                if((flags & element.Key) != 0) { ((ICommand)Activator.CreateInstance(element.Value, marioPlayer)).Execute(); }
            }
            flags = 0b00000000; //Reset flags.
        }
        public void ChangeFlags(int command)
        {
            flags |= command; //Bitwise Update.
        }
    }
}
