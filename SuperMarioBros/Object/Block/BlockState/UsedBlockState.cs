using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class UsedBlockState : IBlockState
    {
        public UsedBlockState(IBlock block)
        {
            block.ChangeSprite(SpriteFactory.CreateSprite(this.GetType().Name));
        }

        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
