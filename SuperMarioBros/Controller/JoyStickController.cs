using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBros.Controllers
{
    class JoyStickController : IController
    {
        private readonly ControllerMessager messager;
        public JoyStickController(ControllerMessager controllerMessager)
        {
            messager = controllerMessager;
        }
        public void Update(GameTime gameTime)
        {
            Vector2 joyStickState = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            var buttons = GamePad.GetState(PlayerIndex.One).Buttons;
            if (joyStickState.X > 0.1)
            {
                messager.ChangeFlags(ControllerMessager.RIGHTMOVE);
            }
            if (joyStickState.X < -0.1)
            {
                messager.ChangeFlags(ControllerMessager.LEFTMOVE);
            }
            if (joyStickState.Y > 0.1)
            {
                messager.ChangeFlags(ControllerMessager.DOWNMOVE);
            }
            if (buttons.A.Equals(ButtonState.Pressed))
            {
                messager.ChangeFlags(ControllerMessager.UPMOVE);
            }
            if (buttons.B.Equals(ButtonState.Pressed))
            {
                messager.ChangeFlags(ControllerMessager.POWER);
            }
        }
    }
}
