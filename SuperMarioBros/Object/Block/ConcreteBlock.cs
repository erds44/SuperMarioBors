using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class ConcreteBlock : AbstractBlock
    {
        public ConcreteBlock( Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(this.GetType().Name);
        }
    }
}
