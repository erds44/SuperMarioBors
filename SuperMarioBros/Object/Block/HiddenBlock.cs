using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class HiddenBlock : AbstractBlock
    {
        public HiddenBlock( Point location)
        {
            this.Location = location;
            this.State = new HiddenBlockState(this);
        }
    }
}
