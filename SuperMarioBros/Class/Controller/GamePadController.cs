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
        private Invoker currInvoker;
        private Invoker defaultInvoker;
        private Dictionary<GamePadButtons, Invoker> inputKeys;
        public GamePadController(MarioGame game)
        {
            inputKeys = new Dictionary<GamePadButtons, Invoker>();
            receiver = new InputAction(game);
            defaultInvoker = new Invoker(new FaceLeftOrRightCommand(receiver));
            Initialize();
        }

        private void Initialize()
        {
            inputKeys.Add(new GamePadButtons(Buttons.Start), new Invoker(new Quit(receiver)));
            // More Keys TBD

        }
        public void Update()
        {
            GamePadButtons button = GamePad.GetState(PlayerIndex.One).Buttons;
            if (inputKeys.TryGetValue(button, out currInvoker))
            {
                currInvoker.press();
            }
            else
            {
                defaultInvoker.press();
            }
        }
    }
}
