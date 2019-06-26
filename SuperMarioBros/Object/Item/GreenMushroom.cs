using Microsoft.Xna.Framework;

namespace SuperMarioBros.Items
{
    public class GreenMushroom : AbstractItem, IItem
    {
        private Vector2 GreenMushrromCollidableVelicity = new Vector2(80, 0);
        public GreenMushroom(Vector2 location)
        {
            Position = location;
            base.Initialize();
            collidableVelocity = GreenMushrromCollidableVelicity;
        }
    }
}
