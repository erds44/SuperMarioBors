using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class UsedBlockState : IBlockState
    {
        private readonly static string type = "EmptyBlock";
       // private readonly IBlockObject block;
        public UsedBlockState(IBlock block)
        {
           // this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
        }

        public void ToDisappear()
        {
            //Do nothing.
        }

        public void ToUsed()
        {
            // Do Nothing
        }

        public void Update()
        {
            //Do nothing.
        }
    }
}
