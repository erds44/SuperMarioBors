using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public class ItemBlockResponse : GeneralResponse
    {
        private IBlock block;
        private IItem item;
        private Direction direction;
        private delegate void MarioItemHandler(IItem item, IBlock block);

        public ItemBlockResponse(IObject item, IObject block, Direction direction)
        {
            this.block = (IBlock)block;
            this.item = (IItem)item;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if (item is FireBall)
                FireBallCollision();
            else if (item is Star)
                StarCollision();
            else if (!(block is HiddenBlock))
            {
                switch (direction)
                {
                    case Direction.top: ItemBumpedOrChangeDirection(); break;
                    case Direction.bottom: OnGround(item); break;
                    default: LeftOrRightBounce(item); break;
                }
                ResolveOverlap(item, block, direction);
            }           
        }
        private void ItemBumpedOrChangeDirection()
        {
            if (block.State is BumpedState)
            {
                Bump(item);
                if (item.HitBox().Center.X <= block.HitBox().Center.X)
                    ChangeDirection(item);
            }
            else
                OnGround(item);
        }
        private void FireBallCollision()
        {
            if (!(block is HiddenBlock))
            {
                switch (direction)
                {
                    case Direction.top: GroundOrTopBounce(item); ResolveOverlap(item, block, direction); break;
                    case Direction.bottom: GroundOrTopBounce(item); ResolveOverlap(item, block, direction); break;
                    default:
                        ((FireBall)item).FireExplosion();
                        item.ObjState = ObjectState.NonCollidable;
                        break;
                }
            }
        }
        private void StarCollision()
        {
            if (!(block is HiddenBlock))
            {
                switch (direction)
                {
                    case Direction.top: GroundOrTopBounce(item); break;
                    case Direction.bottom: GroundOrTopBounce(item); break;
                    default: LeftOrRightBounce(item); break;
                }
                ResolveOverlap(item, block, direction);
            }
        }
    }
}
