using Microsoft.Xna.Framework;
using SuperMarioBros.Marios;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Flower :AbstractItem, IItem
   {
        public Flower(Vector2 location)
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
