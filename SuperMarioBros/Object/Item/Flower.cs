using Microsoft.Xna.Framework;
using SuperMarioBros.Marios;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Flower :AbstractItem, IItem
   {
        public Flower(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }
    }
}
