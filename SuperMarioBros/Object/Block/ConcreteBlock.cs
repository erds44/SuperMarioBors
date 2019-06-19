using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;

namespace SuperMarioBros.Blocks
{
    public class ConcreteBlock : AbstractBlock
    {
        public ConcreteBlock( Vector2 location)
        {
            Position = location;
            this.State = new ConcreteBlockState(this);
            base.Initialize();
        }
    }
}
