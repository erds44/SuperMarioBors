using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.Objects;

namespace SuperMarioBros.Classes.Collision
{
    public static class MarioMushroomCollisionHandler
    {
        public static bool HandleCollision(IMario mario, IMushroom mushroom, string type)
        {
            if (!type.Equals("None"))
            {
                mushroom.Collide(mario);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
