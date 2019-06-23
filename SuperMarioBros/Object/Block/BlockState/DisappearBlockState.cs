using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class DisappearBlockState : IBlockState
    {
        public DisappearBlockState(IBlock block)
        {
            block.ChangeSprite(SpriteFactory.CreateSprite(this.GetType().Name));
            block.ObjState = ObjectState.Destroy;
        }

        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
