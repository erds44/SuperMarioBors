using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.BlockObject.BlockState
{
    public class ConcreteBlockState : IBlockState
    {
        private readonly static string type = "ConcreteBlock";
        //private readonly IBlockObject block;

        public ConcreteBlockState(IBlockObject block)
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
