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
                int overlapy = overlap.Y;
                int overlapWidth = overlap.Width;

                obj2x = object2.HitBox().X;
                obj2y = object2.HitBox().Y;
                obj2Width = object2.HitBox().Width;

                if(overlapy == obj2y)
                {
                    return Direction.top;
                }
                else if (overlapx == obj2x)
                {
                    return Direction.left;
                }
                else if (overlapx + overlapWidth == obj2x + obj2Width)
                {
                    return Direction.right;
                }
                else
                {
                    return Direction.bottom;
                }

            }
            return Direction.none;
        }

    }   
}
