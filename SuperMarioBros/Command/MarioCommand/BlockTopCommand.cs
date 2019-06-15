using SuperMarioBros.Collisions;
using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class BlockTopCommand : ICommand
    {
        private readonly IMario mario;
        public BlockTopCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Obstacle(Direction.top);
        }
    }
}
