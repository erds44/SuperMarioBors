using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Items
{
    public class MiddlePipe : AbstractBlock
    {
        public MiddlePipe(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
