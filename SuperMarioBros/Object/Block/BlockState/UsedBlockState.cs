using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class EmptyBlockState : IBlockState
    {
        private readonly static string type = "EmptyBlock";
       // private readonly IBlockObject block;
        public EmptyBlockState(IBlock block)
        {
           // this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
        }

        public void ToUsed()
        {
            // Do Nothing
        }
    }
}
