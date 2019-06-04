using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object.ItemObject;
using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class CoinObject : AbstractItem, IItem

    {
        public CoinObject(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Coin");
        }

        public void Collide(IMario mario)
        {
            // Do Nothing
        }
    }
}

