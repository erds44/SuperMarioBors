using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Commands;
using SuperMarioBros.Marios;
using System.Collections.Generic;

namespace SuperMarioBros.Controllers
{
    public class JoyStickController : IController
    {
        IMario mario;
        private readonly Dictionary<Buttons, ICommand> buttonDownDictionary = new Dictionary<Buttons, ICommand>();
        private readonly Dictionary<Buttons, ICommand> buttonUpDictionary = new Dictionary<Buttons, ICommand>();
        private readonly List<Buttons> checkButtonUplist = new List<Buttons>();
        private readonly List<Buttons> nonHoldableButtons = new List<Buttons>();

        public bool IsPause { get; set; }

        public JoyStickController(IMario mario, params (Buttons key, ICommand buttonDownCommand, ICommand buttonUpCommand, bool CanBeHeld)[] args)
        {
            this.mario = mario;
            foreach (var (button, downCommand, upCommand, canBeHeld) in args)
            {
                buttonDownDictionary.Add(button, downCommand);
                buttonUpDictionary.Add(button, upCommand);
                if (!canBeHeld)
                    nonHoldableButtons.Add(button);
            }
        }
        public void Update(GameTime gameTime)
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.IsConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);
                Vector2 joyStickState = state.ThumbSticks.Left;
                joyStickHandler(joyStickState);
                foreach (Buttons buttonUp in checkButtonUplist)
                {
                    if (state.IsButtonUp(buttonUp) && buttonUpDictionary.TryGetValue(buttonUp, out ICommand buttonUpCommand))
                        buttonUpCommand.Execute();
                }
                checkButtonUplist.Clear();
                foreach (Buttons buttonDown in buttonDownDictionary.Keys)
                {
                    if (state.IsButtonDown(buttonDown))
                    {
                        if (!nonHoldableButtons.Contains(buttonDown) || !checkButtonUplist.Contains(buttonDown))
                            buttonDownDictionary[buttonDown].Execute();
                        if (!checkButtonUplist.Contains(buttonDown))
                            checkButtonUplist.Add(buttonDown);
                    }
                }
            }         
        }
        private void joyStickHandler(Vector2 joyStickState)
        {
                if (joyStickState.Y < -0.1)
                {
                    mario.Down();
                }
                else if (joyStickState.X < -0.1)
                {
                    mario.Left();
                }
                else if (joyStickState.X > 0.1)
                {
                    mario.Right();
                }
                else
                {
                    mario.Idle();
                }
        }

            

        
    }
}
