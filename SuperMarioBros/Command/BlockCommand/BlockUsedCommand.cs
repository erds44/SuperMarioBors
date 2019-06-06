using SuperMarioBros.Blocks;

namespace SuperMarioBros.Commands
{
    class BlockUsedCommand : ICommand
    {
        private readonly Block block;
        public BlockUsedCommand(Block block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.Used();
        }
    }
}
