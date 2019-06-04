using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Classes.Object.ItemObject;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class FlowerObject :AbstractItem, IObject
   {
        public FlowerObject(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Flower");
        }
    }
}
