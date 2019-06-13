using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class QuestionBlock : AbstractBlock
    {
        public QuestionBlock(Point location)
        {
            this.location = location;
            state = new QuestionBlockState(this);
        }
    }
}
