using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{
    public class MiddleCloud : AbstractBackground
    {
        public MiddleCloud(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }
    }
}
