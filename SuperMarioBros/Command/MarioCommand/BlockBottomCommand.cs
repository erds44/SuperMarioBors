using SuperMarioBros.Collisions;
using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class BlockBottomCommand : ICommand
    {
        private readonly IMario mario;
        public BlockBottomCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Obstacle(Direction.bottom);
        }
    }
}
