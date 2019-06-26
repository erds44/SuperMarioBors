using Microsoft.Xna.Framework;

namespace SuperMarioBros.Blocks
{
    public class RockBlock : AbstractBlock
    {
        public RockBlock(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
