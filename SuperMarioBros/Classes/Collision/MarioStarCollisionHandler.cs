using SuperMarioBros.Classes.Object;
using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros.Classes.Collision
{
    public static class MarioStarCollisionHandler
    {
        public static bool HandleCollision(ObjectsManager objectsManager,IMario mario, IStar star, string type)
        {
            if (!type.Equals("None"))
            {
                star.Collide(objectsManager, mario);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
