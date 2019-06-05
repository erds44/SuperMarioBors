using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class QuestionBlockState : IBlockState
    {
        private readonly static string type = "QuestionBlock";
        private readonly IBlock block;

        public QuestionBlockState(IBlock block)
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
