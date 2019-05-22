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
    class KeyboardController : IController
    {
        private IReceiver receiver;
        private Invoker currInvoker;
        private Invoker defaultInvoker;
        private Dictionary<Keys, Invoker> inputKeys;
        public KeyboardController(MarioGame game)
        {
            inputKeys = new Dictionary<Keys, Invoker>();
            receiver = new InputAction(game);
            defaultInvoker = new Invoker(new FaceLeftOrRightCommand(receiver));
            Initialize();
        }

        private void Initialize()
        {
            inputKeys.Add(Keys.Q, new Invoker(new Quit(receiver)));
            inputKeys.Add(Keys.A, new Invoker(new MoveLeftCommand(receiver)));
            inputKeys.Add(Keys.D, new Invoker(new MoveRightCommand(receiver)));

        }
        public void Update()
        {
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            if (key.Count() > 0)
            {
                if(inputKeys.TryGetValue(key[0], out currInvoker))
                {
                    currInvoker.press();
                }
                else
                {
                    defaultInvoker.press();
                }
            }
            else
            {
                defaultInvoker.press();
            }

        }
    }
}
