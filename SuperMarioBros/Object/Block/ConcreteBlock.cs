using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class ConcreteBlock : AbstractBlock
    {
        public ConcreteBlock(Point location)
        {
            this.location = location;
            this.sprite = SpriteFactory.CreateSprite(this.GetType().Name);
        }

        public override Rectangle HitBox()
        {
            return new Rectangle(location.X, location.Y - sprite.Height(), sprite.Width(), sprite.Height());
        }
        public override void Used()
        {
            // Do nothing.
        }
    }
}
