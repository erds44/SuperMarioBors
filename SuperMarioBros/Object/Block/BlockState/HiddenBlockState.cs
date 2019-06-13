using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class HiddenBlockState : IBlockState
    {
        private readonly IBlock block;
        public HiddenBlockState(IBlock block)
        {
            this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(this.GetType().Name));
        }
        public void ToUsed()
        {
            block.ChangeState(new UsedBlockState(block));
        }
    }
}
