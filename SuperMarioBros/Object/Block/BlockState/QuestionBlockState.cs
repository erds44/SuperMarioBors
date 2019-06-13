using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class QuestionBlockState : IBlockState
    {
        private readonly IBlock block;

        public QuestionBlockState(IBlock block)
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
