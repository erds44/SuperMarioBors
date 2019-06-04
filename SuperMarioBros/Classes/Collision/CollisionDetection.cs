using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Collision
{
    public static class CollisionDetection
    {
        private static int obj1x;
        private static int obj1y;
        private static int obj1Width;
        private static int obj1Height;
        private static int obj2x;
        private static int obj2y;
        private static int obj2Width;
        private static int obj2Height;
        public static string Detect(IObject object1, IObject object2)
        {
            if (object1.HitBox().Intersects(object2.HitBox()))
            {
                obj1x = object1.HitBox().X;
                obj1y = object1.HitBox().Y;
                obj1Width = object1.HitBox().Width;
                obj1Height = object1.HitBox().Height;

                obj2x = object2.HitBox().X;
                obj2y = object2.HitBox().Y;
                obj2Width = object2.HitBox().Width;
                obj2Height = object2.HitBox().Height;

                int dx = obj2x + 1 / 2 * obj2Width - obj1x - 1 / 2 * obj1Width;
                int dy = obj1y + 1 / 2 * obj1Height - obj2y - 1 / 2 * obj2Height;

                return Compare(dx, dy);
            }
            return "None";

        }
        private static string Compare(int dx, int dy)
        {
            if(dx > 0)
            {
                if(dy > 0)
                {
                    if(obj1Width + obj1x - obj2x > obj2y + obj2Height - obj1y)
                    {
                        return "Bottom";
                    }
                    else
                    {
                        return "Left";
                    }
                }
                else
                {
                    if(obj1Width + obj1x - obj2x > obj1y + obj1Height - obj2y)
                    {
                        return "Top";
                    }
                    else
                    {
                        return "Left";
                    }
                }
            }
            else
            {
                if(dy > 0)
                {
                    if(obj2x + obj2Width - obj1x > obj2y + obj2Height - obj1y)
                    {
                        return "Bottom";
                    }
                    else
                    {
                        return "Right";
                    }
                }
                else
                {
                    if(obj2x + obj2Width - obj1x > obj1y + obj1Height - obj2y)
                    {
                        return "Top";
                    }
                    else
                    {
                        return "Right";
                    }
                }
            }
        }
        

    }   
}
