using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class ObstacleCommand : ICommand
    {
        private readonly IMario mario;
        public ObstacleCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Obstacle();
        }
    }
}
