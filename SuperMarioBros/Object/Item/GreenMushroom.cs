using Microsoft.Xna.Framework;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Items
{
    public class GreenMushroom : AbstractItem, IItem
    {
        public GreenMushroom(Vector2 location)
        {
            Position = location;
            base.Initialize();
            collidableVelocity = PhysicsConsts.GreenMushrromCollidableVelicity;
        }
    }
}
