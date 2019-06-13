using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{

    public class BigCloud : AbstractBackground
    {

        public BigCloud(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }
    }
}
