using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class HiddenBlockState : IBlockState
    {
        private readonly static string type = "HiddenBlock";
        private readonly IBlock block;
        public HiddenBlockState(IBlock block)
        {
            this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
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
