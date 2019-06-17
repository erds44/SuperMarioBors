using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class BlockUsedCommand : ICommand
    {
        private readonly IBlock block;
        public BlockUsedCommand(IStatic block)
        {
            this.block =(IBlock) block;
        }
        public void Execute()
        {
            block.Used();
        }
    }
}
