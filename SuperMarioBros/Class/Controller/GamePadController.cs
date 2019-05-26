using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using SuperMarioBros.Class.Command;

namespace SuperMarioBros.Class.Controller
{
    class GamePadController : IController
    {
        private Dictionary<GamePadButtons, ICommand> inputKeys;
        public GamePadController()
        {
            inputKeys = new Dictionary<GamePadButtons, ICommand>();
        }

        public  void Add (GamePadButtons key, ICommand command)
        {
            inputKeys.Add(key, command);
        }


        //private void Initialize()
        //{
        //    inputKeys.Add(new GamePadButtons(Buttons.Start), new Quit(receiver));
        //    // More Keys TBD

        //}
        public void Update()
        {
            GamePadButtons button = GamePad.GetState(PlayerIndex.One).Buttons;
            ICommand command;
            if (inputKeys.TryGetValue(button, out command))
            {
                command.Execute();
            }
        }

    }
}
