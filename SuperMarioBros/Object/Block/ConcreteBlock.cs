using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class ConcreteBlock : AbstractBlock
    {
        public ConcreteBlock( Point location)
        {
            this.location = location;
            this.state = new ConcreteBlockState(this);
        }
    }
}
