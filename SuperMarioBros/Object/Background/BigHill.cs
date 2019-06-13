using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{
    public class BigHill : AbstractBackground
    {
        public BigHill(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }



    }
}
