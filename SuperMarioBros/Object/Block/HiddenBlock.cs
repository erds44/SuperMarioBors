using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class HiddenBlock : AbstractBlock
    {
        public HiddenBlock( Vector2 location)
        {
            this.location = location;
            this.state = new HiddenBlockState(this);
        }
    }
}
