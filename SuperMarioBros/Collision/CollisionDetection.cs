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
        private static int obj2Height;
        /*
          The Collision Detection Method has many branches,
          It is hard to make it elegent right now
          Basically, it covers 8 different cases of collision
          4 caes for sides, 4 cases for corners              
        */
        public static Direction Detect(IObject object1, IObject object2)
        {
            if (object1.HitBox().Intersects(object2.HitBox()))
            {
                Rectangle overlap = Rectangle.Intersect(object1.HitBox(), object2.HitBox());
                int overlapx = overlap.X;
                int overlapy = overlap.Y;
                int overlapWidth = overlap.Width;
                int overlapHeight = overlap.Height;

                obj2x = object2.HitBox().X;
                obj2y = object2.HitBox().Y;
                obj2Width = object2.HitBox().Width;
                obj2Height = object2.HitBox().Height;

                if(overlapy == obj2y)
                {
                    if(overlapx == obj2x)
                    {
                        if(overlapWidth > overlapHeight)
                        {
                            return Direction.top;
                        }
                        else
                        {
                            return Direction.right;
                        }
                    }else if(overlapx + overlapWidth == obj2x + obj2Width)
                    {
                        if (overlapWidth > overlapHeight)
                        {
                            return Direction.top;
                        }
                        else
                        {
                            return Direction.right;
                        }
                    }
                    else
                    {
                        return Direction.top;
                    }
                }
                else if (overlapx == obj2x)
                {
                    if(overlapy + overlapHeight == obj2y + obj2Height)
                    {
                        if (overlapWidth > overlapHeight)
                        {
                            return Direction.bottom;
                        }
                        else
                        {
                            return Direction.left;
                        }
                    }
                    else
                    {
                        return Direction.left;
                    }
                }
                else if (overlapx + overlapWidth == obj2x + obj2Width)
                {
                    if(overlapy + overlapHeight == obj2y + obj2Height)
                    {
                        if (overlapWidth > overlapHeight)
                        {
                            return Direction.bottom;
                        }
                        else
                        {
                            return Direction.right;
                        }
                    }
                    else
                    {
                        return Direction.right;
                    }
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
