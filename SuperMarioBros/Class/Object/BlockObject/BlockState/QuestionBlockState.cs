using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.BlockObject.BlockState
{
    public class QuestionBlockState : IBlockState
    {
        private readonly static string type = "QuestionBlock";
        private readonly IBlockObject block;

        public QuestionBlockState(IBlockObject block)
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
        public void ToUsed()
        {
            block.ChangeState(new UsedBlockState(block));
        }

        public void ToDisappear()
        {
            //Do nothing.
        }
    }
}
