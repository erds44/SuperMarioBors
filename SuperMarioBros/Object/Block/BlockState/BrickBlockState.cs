using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class BrickBlockState : IBlockState
    {
        private readonly IBlock block;

        public BrickBlockState(IBlock block)
        {
            this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(this.GetType().Name));
        }

        public void ToUsed()
        {
            block.ChangeState(new DisappearBlockState(block));
        }
    }
}
