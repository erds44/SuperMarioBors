using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Object.Pipes;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public class ItemPipeResponse : GeneralResponse
    {
        private readonly IPipe pipe;
        private IItem item;
        private readonly Direction direction;
        private delegate void MarioItemHandler(IItem item, IPipe pipe);

        public ItemPipeResponse(IObject item, IObject pipe, Direction direction)
        {
            this.pipe = (IPipe)pipe;
            this.item = (IItem)item;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if (item is FireBall)
                FireBallCollision();
            else if (item is Star)
                StarCollision();
            else
            {
                switch (direction)
                {
                    case Direction.top: OnGround(item); break;
                    case Direction.bottom: OnGround(item); break;
                    default: LeftOrRightBounce(item); break;
                }
                ResolveOverlap(item, pipe, direction);
            }
        }
        private void FireBallCollision()
        {
            switch (direction)
            {
                case Direction.top: GroundOrTopBounce(item); ResolveOverlap(item, pipe, direction); break;
                case Direction.bottom: GroundOrTopBounce(item); ResolveOverlap(item, pipe, direction); break;
                default:
                    ((FireBall)item).FireExplosion();
                    item.ObjState = ObjectState.NonCollidable;
                    break;
            }
        }
        private void StarCollision()
        {
            switch (direction)
            {
                case Direction.top: GroundOrTopBounce(item); break;
                case Direction.bottom: GroundOrTopBounce(item); break;
                default: LeftOrRightBounce(item); break;
            }
            ResolveOverlap(item, pipe, direction);
        }
    }
}
