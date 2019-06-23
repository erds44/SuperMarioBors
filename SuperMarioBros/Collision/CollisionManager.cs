using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public enum Direction { left, right, top, bottom, none }
    public class CollisionManager
    {
        private DynamicAndStaticObjectsHandler staticHandler;
        private DynamicAndDynamicObjectsHandler dynamicHandler;
        public CollisionManager()
        {
            staticHandler = new DynamicAndStaticObjectsHandler();
            dynamicHandler = new DynamicAndDynamicObjectsHandler();
        }

        public void HandleCollision(IDynamic obj1, IDynamic obj2)
        {
            Direction direction = Detect(obj1, obj2);
            dynamicHandler.HandleCollision(obj1, obj2, direction);
        }
        public void HandleCollision(IDynamic obj1, IStatic obj2)
        {
            Direction direction = Detect(obj1, obj2);
            staticHandler.HandleCollision(obj1, obj2, direction);
        }
        private Direction Detect(IObject object1, IObject object2)
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
