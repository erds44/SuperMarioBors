using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Pipes;

namespace SuperMarioBros.Collisions
{
    public class ItemPipeCollisionHandler : GeneralHandler
    {
        public static void FireExplosion(IItem item, IPipe pipe, Direction direction)
        {
            ((FireBall)item).FireExplosion();
        }
    }
}
