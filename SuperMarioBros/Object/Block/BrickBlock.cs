using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class BrickBlock : AbstractBlock 
    {
        public BrickBlock( Vector2 location)
        {
            this.location = location;
            this.state = new BrickBlockState(this);
        }

    }
}
