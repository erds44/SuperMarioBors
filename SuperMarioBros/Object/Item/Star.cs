using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Star : AbstractItem, IItem
    {
        public Star(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Star");
        }
    }
}

