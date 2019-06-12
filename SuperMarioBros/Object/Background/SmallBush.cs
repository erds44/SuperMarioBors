using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{

    public class SmallBush : AbstractBackground
    {

        public SmallBush(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("SmallBush");
        }
    }
}
