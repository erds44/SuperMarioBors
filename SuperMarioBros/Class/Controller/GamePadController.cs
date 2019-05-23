using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SuperMarioBros
{
    class GamePadController : IController
    {
        private IReceiver receiver;
        private Dictionary<GamePadButtons, ICommand> inputKeys;
        public GamePadController(MarioGame game)
        {
            inputKeys = new Dictionary<GamePadButtons, ICommand>();
            receiver = new InputAction(game);
            Initialize();
        }

        private void Initialize()
        {
            inputKeys.Add(new GamePadButtons(Buttons.Start), new Quit(receiver));
            // More Keys TBD

        }
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
