using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class HiddenBlock : AbstractBlock
    {
        public HiddenBlock(Vector2 location)
        {
            Position = location;
            this.State = new HiddenBlockState(this);
        }
    }
}
