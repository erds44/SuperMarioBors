using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class ConcreteBlock : AbstractBlock
    {
        public ConcreteBlock(Vector2 location)
        {
            ItemType = null;
            HasItem = false;
            Position = location;
            base.Initialize();
        }
        public override void Used()
        {
            // Do Nothing
        }
    }
}
