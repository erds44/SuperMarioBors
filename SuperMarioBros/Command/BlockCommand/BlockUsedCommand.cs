using SuperMarioBros.Blocks;

namespace SuperMarioBros.Commands
{
    class BlockUsedCommand : ICommand
    {
        private readonly IBlock block;
        public BlockUsedCommand(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.Used();
        }
    }
}
