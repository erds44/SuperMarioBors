using SuperMarioBros.Collisions;
using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class BlockLeftAndRightCommand : ICommand
    {
        private readonly IMario mario;
        public BlockLeftAndRightCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Obstacle(Direction.left);
        }
    }
}
