using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class ConcreteBlockState : IBlockState
    {
        private readonly static string type = "ConcreteBlock";
        //private readonly IBlockObject block;

        public ConcreteBlockState(IBlock block)
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
