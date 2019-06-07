using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class HiddenObstacleCommand : ICommand
    {
        private readonly IMario mario;
        public HiddenObstacleCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (mario.MarioPhysics.Direction() > 0)
            {
                mario.Obstacle();
            }
        }
    }
}
