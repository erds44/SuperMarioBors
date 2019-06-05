using SuperMarioBros.Blocks;

namespace SuperMarioBros.Commands
{
    class BlockDisappearCommand : ICommand
    {
        private readonly IBlock block;
        public BlockDisappearCommand(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.Disappear();
        }
    }
}
