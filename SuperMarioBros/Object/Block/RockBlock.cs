using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class RockBlock : AbstractBlock
    {
        public RockBlock( Point location)
        {
            this.Location = location;
            State = new RockBlockState(this);
        }
    }
}
