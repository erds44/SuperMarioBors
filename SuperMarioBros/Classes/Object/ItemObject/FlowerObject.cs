using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object.ItemObject;
using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class FlowerObject :AbstractItem, IItem
   {
        public FlowerObject(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Flower");
        }

        public void Collide(IMario mario)
        {
            mario.FireFlower();
        }
    }
}
