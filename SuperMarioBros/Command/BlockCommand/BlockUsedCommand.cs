using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;

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
            ObjectsManager.Instance.DecorateObject(block , new UsedBlock(new Point(block.HitBox().X, block.HitBox().Y + block.HitBox().Height)));  
        }
    }
}
