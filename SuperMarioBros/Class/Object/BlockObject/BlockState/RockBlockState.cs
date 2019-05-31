using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.BlockObject.BlockState
{
    public class RockBlockState : IBlockState
    {
        private readonly static string type = "RockBlock";
       // private readonly IBlockObject block;

        public RockBlockState(IBlockObject block)
        {
            //this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
        }

        public string Type()
        {
            return type;
        }

        public void Update()
        {
            //Do nothing.
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
