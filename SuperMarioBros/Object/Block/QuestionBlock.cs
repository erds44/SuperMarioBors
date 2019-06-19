using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class QuestionBlock : AbstractBlock
    {
        public QuestionBlock(Point location)
        {
            this.Location = location;
            State = new QuestionBlockState(this);
            base.Initialize();
        }
    }
}
