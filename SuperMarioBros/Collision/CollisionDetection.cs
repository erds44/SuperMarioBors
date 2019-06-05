using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public enum Direction {left, right, top, bottom, none}
    public static class CollisionDetection
    {
        private static int obj2x;
        private static int obj2y;
        private static int obj2Width;

        public static Direction Detect(IObject object1, IObject object2)
        {
            
            if (object1.HitBox().Intersects(object2.HitBox()))
            {
                Rectangle overlap = Rectangle.Intersect(object1.HitBox(), object2.HitBox());

                int overlapx = overlap.X;
                int overlapWidth = overlap.Width;
                int overlapHeight = overlap.Height;

                obj2x = object2.HitBox().X;
                obj2y = object2.HitBox().Y;
                obj2Width = object2.HitBox().Width;

                if (overlapx == obj2x)
                {
                    return Direction.left;
                }
                else if (overlapx + overlapWidth == obj2x + obj2Width)
                {
                    return Direction.right;
                }
                else if (obj2y - overlapHeight == obj2y)
                {
                    return Direction.bottom;
                }
                else
                {
                    return Direction.top;
                }

            }
            return Direction.none;
        }

    }   
}
