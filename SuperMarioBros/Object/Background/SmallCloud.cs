using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{
    public class SmallCloud : AbstractBackground
    {
        public SmallCloud(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("SmallCloud");
        }
    }
}
