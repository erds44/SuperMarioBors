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
        public void Update()
        {
            Vector2 joyStickState = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
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
            if (joyStickState.Y < -0.1)
            {
                messager.ChangeFlags(ControllerMessager.UPMOVE);
            }
        }
    }
}
