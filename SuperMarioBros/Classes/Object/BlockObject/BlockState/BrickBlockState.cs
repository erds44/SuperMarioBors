using SuperMarioBros.Interfaces.Objects.BlockObjects;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.BlockObjects.BlockStates
{
    public class BrickBlockState : IBlockState
    {
        private readonly static string type = "BrickBlock";
        private readonly IBlockObject block;

        public BrickBlockState(IBlockObject block)
        {
            this.block = block;
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
            block.ChangeState(new DisappearBlockState(block));
        }

        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
