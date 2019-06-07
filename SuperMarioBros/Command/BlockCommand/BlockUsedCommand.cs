using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class BlockUsedCommand : ICommand
    {
        private readonly IBlock block;
        private readonly int index;
        public BlockUsedCommand(IBlock block, int index)
        {
            this.block = block;
            this.index = index;
        }
        public void Execute()
        {
            ObjectsManager.Instance.DecorateObject(new UsedBlock(new Point(block.HitBox().X, block.HitBox().Y + block.HitBox().Height)), index);  
        }
    }
}
