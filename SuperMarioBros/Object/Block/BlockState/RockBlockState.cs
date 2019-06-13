using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class RockBlockState : IBlockState
    {
        public RockBlockState(IBlock block)
        {
            block.ChangeSprite(SpriteFactory.CreateSprite(this.GetType().Name));
        }

        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
