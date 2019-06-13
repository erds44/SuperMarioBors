using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class ConcreteBlock : AbstractBlock
    {
        public ConcreteBlock( Point location)
        {
            this.Location = location;
            this.State = new ConcreteBlockState(this);
        }
    }
}
