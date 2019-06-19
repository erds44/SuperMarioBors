using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class RockBlock : AbstractBlock
    {
        public RockBlock(Vector2 location)
        {
            Position = location;
            State = new RockBlockState(this);
            base.Initialize();
        }
    }
}
