using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Star : AbstractItem, IItem
    {
        public Star(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }

        public void Destroy()
        {
            //Do nothing.
        }
    }
}

