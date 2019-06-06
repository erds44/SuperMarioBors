using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class BrickBlockState : IBlockState
    {
        private readonly string type = "BrickBlock";
        private IBlock block;

        public BrickBlockState(ref IBlock block)
        {
            this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
        }

        public void ToUsed()
        {
            block = new DisappearBlock(location, ref block);
        }
    }
}
