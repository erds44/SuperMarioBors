using SuperMarioBros.Interfaces.Objects.BlockObjects;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.BlockObjects.BlockStates
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
