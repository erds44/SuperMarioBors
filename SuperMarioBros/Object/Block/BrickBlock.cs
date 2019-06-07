using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class BrickBlock : AbstractBlock 
    {
        public BrickBlock( Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(this.GetType().Name);
        }

    }
}
