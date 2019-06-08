using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class HiddenBlockUsedCommand : ICommand
    {
        private readonly IBlock block;
        private readonly int index;
        public HiddenBlockUsedCommand(IBlock block, int index)
        {
            this.block = block;
            this.index = index;
        }
        public void Execute()
        {
            if (ObjectsManager.Instance.Mario.MarioPhysics.Direction() < 0)
            {
                ObjectsManager.Instance.DecorateObject(new UsedBlock(new Point(block.HitBox().X, block.HitBox().Y + block.HitBox().Height)), index);
            }
        }
    }
}
