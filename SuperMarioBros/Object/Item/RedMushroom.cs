using Microsoft.Xna.Framework;

namespace SuperMarioBros.Items
{
    public class RedMushroom : AbstractItem, IItem
    {
        public RedMushroom(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
