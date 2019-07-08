using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public abstract class GeneralHandler 
    {
        /* Below are some help methods shared by every response class */
        private readonly static float bumpedVelocity = -180f;
        protected static void MoverOnGround(IObject mover, IObject target, Direction direction)
        {
            mover.Physics.Velocity = new Vector2(mover.Physics.Velocity.X, 0);
            ResolveOverlap(mover, target, direction);
        }
        protected static void MoverVerticallyBounce(IObject mover, IObject target, Direction direction)
        {
            mover.Physics.Velocity = new Vector2(mover.Physics.Velocity.X, -mover.Physics.Velocity.Y);
            ResolveOverlap(mover, target, direction);
        }
        protected static void MoverHorizontallyBounce(IObject mover, IObject target, Direction direction)
        {
            mover.Physics.Velocity = new Vector2(-mover.Physics.Velocity.X, mover.Physics.Velocity.Y);
            ResolveOverlap(mover, target, direction);
        }
        protected static void MoverHorizontallyBlock(IObject mover, IObject target, Direction direction)
        {
            mover.Physics.Velocity = new Vector2(0, mover.Physics.Velocity.Y);
            ResolveOverlap(mover, target, direction);
        }
        protected static void ResolveOverlap(IObject obj1, IObject obj2, Direction direction)
        {
            Rectangle overlap = Rectangle.Intersect(obj1.HitBox(), obj2.HitBox());
            switch (direction)
            {
                case Direction.bottom: obj1.Position = new Vector2(obj1.Position.X, obj1.Position.Y + overlap.Height); break;
                case Direction.top: obj1.Position = new Vector2(obj1.Position.X, obj1.Position.Y - overlap.Height); break;
                case Direction.right: obj1.Position = new Vector2(obj1.Position.X + overlap.Width, obj1.Position.Y); break;
                default: obj1.Position = new Vector2(obj1.Position.X - overlap.Width, obj1.Position.Y); break;
            }
        }
        protected static void Bump(IObject obj)
        {
            obj.Physics.Velocity = new Vector2(obj.Physics.Velocity.X, bumpedVelocity);
        }
        protected static void ChangeDirection(IObject obj)
        {
            obj.Physics.Velocity = new Vector2(-obj.Physics.Velocity.X, obj.Physics.Velocity.Y);
        }
        protected static Direction ReverseDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.bottom: return Direction.top;
                case Direction.top: return Direction.bottom;
                case Direction.left: return Direction.right;
            }
            return Direction.left;
        }
    }
}
