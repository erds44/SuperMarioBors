using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class HiddenBlock : AbstractBlock
    {
        public HiddenBlock( Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(this.GetType().Name);
        }
    }
}
