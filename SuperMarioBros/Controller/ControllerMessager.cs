using Microsoft.Xna.Framework;
using SuperMarioBros.Commands;
using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Controllers
{
    /* The purpose of this class is to solve the issue with W, and Up pressed at the same time in one Update 
       Otherwise Mario is expected to be move at doule speed
       The general idea is to use bit wise operation to make sure only one Up command gets called even pressed W or Up multiple times in one Update call 
     */
    public class ControllerMessager : IUpdatable
    {
        private int flags = 0b0000000000;
        public const int UPMOVE = 0b0000000001, DOWNMOVE = 0b0000000010, LEFTMOVE = 0b0000000100, RIGHTMOVE = 0b0000001000, RESETGAME = 0b0000010000, QUITGAME = 0b0000100000, POWER = 0b0001000000, KEYUPUPMOVE = 0b0010000000, KEYUPPOWER = 0b0100000000, KEYDOWNUP = 0b1000000000;
        private readonly IMario marioPlayer;
        private readonly MarioGame game;
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
            { KEYUPPOWER, typeof(KeyUpPowerCommand) },
            { KEYDOWNUP, typeof(KeyDownUpCommand) },

        };
        public ControllerMessager(IMario mario, MarioGame game)
        {
            marioPlayer = mario;
            this.game = game;
            controllers = new List<IController>();
        }
        public void AddController(IController controller)
        {
            controllers.Add(controller);
        }
        public void Update(GameTime gameTime)
        {
            foreach(IController controller in controllers)
            {
                controller.Update(gameTime);
            }
            if(flags == 0)
            {
                new IdleCommand(marioPlayer).Execute();
            }
            marioPlayer.PowerFlag = (flags & POWER) != 0; //Bind power flag.
            foreach(KeyValuePair<int, Type> element in gameCommand)
            {
                if((flags & element.Key) != 0) { ((ICommand)Activator.CreateInstance(element.Value, game)).Execute(); }
            }
            foreach(KeyValuePair<int, Type> element in actionCommand)
            {
                if((flags & element.Key) != 0) { ((ICommand)Activator.CreateInstance(element.Value, marioPlayer)).Execute(); }
            }
            flags = 0b0000000000; //Reset flags.
        }
        public void ChangeFlags(int command)
        {
            flags |= command; //Bitwise Update.
        }
    }
}
