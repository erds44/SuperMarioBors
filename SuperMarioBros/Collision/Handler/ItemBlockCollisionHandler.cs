using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;

namespace SuperMarioBros.Collisions
{
    public class ItemBlockCollisionHandler : GeneralHandler
    {
        public static void FireBallExplosion(IItem item, IBlock block, Direction direction)
        {
            ((FireBall)item).FireExplosion();
            item.ObjState = ObjectState.NonCollidable;
        }

        public static void ItemBumpedOrChangeDirection(IItem item, IBlock block, Direction direction)
        {
            Bump(item);
            if (item.HitBox().Center.X <= block.HitBox().Center.X)
                ChangeDirection(item);
            ResolveOverlap(item, block, direction);
        }
    }
}
