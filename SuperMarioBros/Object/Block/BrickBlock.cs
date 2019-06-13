using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class BrickBlock : AbstractBlock 
    {
        public BrickBlock( Point location)
        {
            this.location = location;
            this.state = new BrickBlockState(this);
        }

    }
}
