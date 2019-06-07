using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class RockBlock : AbstractBlock
    {
        public RockBlock( Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(this.GetType().Name);
        }
    }
}
