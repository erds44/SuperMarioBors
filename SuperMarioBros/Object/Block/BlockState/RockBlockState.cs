using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class RockBlockState : IBlockState
    {
        private readonly static string type = "RockBlock";
       // private readonly IBlockObject block;

        public RockBlockState(IBlock block)
        {
            //this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
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
