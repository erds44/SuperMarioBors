using SuperMarioBros.Interfaces.Objects.BlockObjects;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.BlockObjects.BlockStates
{
    public class HiddenBlockState : IBlockState
    {
        private readonly static string type = "HiddenBlock";
        private readonly IBlockObject block;
        public HiddenBlockState(IBlockObject block)
        {
            this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
        }

        public string Type()
        {
            return type;
        }

        public void Update()
        {
            //Do nothing.
        }
        public void ToUsed()
        {
            block.ChangeState(new UsedBlockState(block));
        }

        public void ToDisappear()
        {
            //Do nothing.
        }
    }
}
