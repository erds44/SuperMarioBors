using Microsoft.Xna.Framework;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public enum Direction { left, right, top, bottom, none }
    public static class CollisionDetection
    {
        public static Direction Detect(IObject object1, IObject object2)
        {
            if (object1.HitBox().Intersects(object2.HitBox()))
            {
                Rectangle overlap = Rectangle.Intersect(object1.HitBox(), object2.HitBox());
                if (overlap.Height <= overlap.Width)
                {
                    if (overlap.Center.Y >= object2.HitBox().Center.Y)
                    {
                        return Direction.bottom;
                    }
                    else if(overlap.Center.Y < object2.HitBox().Center.Y)
                    {
                        return Direction.top;
                    }

                }
                else
                {
                    if (overlap.Center.X >= object2.HitBox().Center.X)
                    {
                        return Direction.right;
                    }
                    else if(overlap.Center.X < object2.HitBox().Center.X)
                    {
                        return Direction.left;
                    }

                }
            }
            return Direction.none;
        }

    }
}
