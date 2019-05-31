using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.BlockObject.BlockState
{
    public class UsedBlockState : IBlockState
    {
        private readonly static string type = "EmptyBlock";
       // private readonly IBlockObject block;
        public UsedBlockState(IBlockObject block)
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
            //Do nothing.
        }

        public string Type()
        {
            return type;
        }

        public void Update()
        {
            //Do nothing.
        }
    }
}
