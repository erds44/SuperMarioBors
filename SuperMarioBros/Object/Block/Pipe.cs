using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Items
{
    public class Pipe : AbstractBlock
    {
        public Pipe(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
