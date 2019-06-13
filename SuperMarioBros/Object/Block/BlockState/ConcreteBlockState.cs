using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class ConcreteBlockState : IBlockState
    {
        //private readonly IBlock block;

        public ConcreteBlockState(IBlock block)
        {
            //this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(this.GetType().Name));
        }
        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
