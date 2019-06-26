using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Items
{
    public class HighPipe : AbstractBlock
    {
        public HighPipe(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
