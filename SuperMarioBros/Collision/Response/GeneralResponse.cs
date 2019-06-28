using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public abstract class GeneralResponse : ICollisionResponsible
    {
        /* Below are some help methods shared by every response class */
        private readonly static float bumpedVelocity = -180f;
        protected virtual void OnGround(IObject obj)
        {
            obj.Physics.Velocity = new Vector2(obj.Physics.Velocity.X, 0);
        }
        protected static void GroundOrTopBounce(IObject obj)
        {
            obj.Physics.Velocity = new Vector2(obj.Physics.Velocity.X, -obj.Physics.Velocity.Y);
        }
        protected static void LeftOrRightBounce(IObject obj)
        {
            obj.Physics.Velocity = new Vector2(-obj.Physics.Velocity.X, obj.Physics.Velocity.Y);
        }
        protected static void LeftOrRightBlock(IObject obj)
        {
            obj.Physics.Velocity = new Vector2(0, obj.Physics.Velocity.Y);
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
        public abstract void HandleCollision();
    }
}
