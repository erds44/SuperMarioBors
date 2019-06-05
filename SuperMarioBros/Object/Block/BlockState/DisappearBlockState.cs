using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class DisappearBlockState : IBlockState
    {
       // private readonly IBlockObject block;
        public DisappearBlockState(IBlock block)
        {
            //this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite("HiddenBlock"));
        }

        public void ToDisappear()
        {
            //Do nothing.
        }

        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
