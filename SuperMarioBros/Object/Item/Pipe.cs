using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Pipe : AbstractItem, IItem
    {
        public Pipe(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Pipe");
        }

    }
}
