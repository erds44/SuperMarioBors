using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Coin : AbstractItem, IItem

    {
        public Coin(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Coin");
        }

    }
}

