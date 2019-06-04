using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros.Classes.Collision
{
    public static class MarioItemCollisionHandler
    {
        public static bool HandleCollision(IMario mario, IItem item, string type)
        {
            if (!type.Equals("None"))
            {
                item.Collide(mario);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
