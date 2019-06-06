using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class RockBlock : AbstractBlock
    {
        public RockBlock( Point location)
        {
            this.location = location;
            this.state = new RockBlockState(this);
        }
    }
}
