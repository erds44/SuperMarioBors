using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{
    public class SmallHill : AbstractBackground
    {
        public SmallHill(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("SmallHill");
        }
    }
}
