using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class QuestionBlock : AbstractBlock
    {
        public QuestionBlock(Vector2 location)
        {
            Position = location;
            State = new QuestionBlockState(this);
            base.Initialize();
        }
    }
}
