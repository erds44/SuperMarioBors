using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public static class MarioStarCollisionHandler
    {
        public static bool HandleCollision(ObjectsManager objectsManager,IMario mario, IStar star, Direction direction)
        {
            if (direction != Direction.none)
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
