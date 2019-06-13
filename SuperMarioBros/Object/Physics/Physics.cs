using Microsoft.Xna.Framework;

namespace SuperMarioBros.Physicses
{
    public class Physics
    {
        private readonly int xVelocity;
        private readonly int yVelocity;
        private Point displacement;
        private Point prevDisplacement;
        public Physics(int xVelocity, int yVelocity)
        {
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
            displacement = new Point(0, 0);
        }
        public void Left()
        {
            displacement.X -= xVelocity;
        }
        public void Right()
        {
            displacement.X += xVelocity;
        }
        public void Up()
        {
            displacement.Y -= yVelocity;
        }
        public void Down()
        {
            displacement.Y += yVelocity;
        }
        public Point Displacement()
        {
            /* If making motion as property, it will be tedious to make changes to motion
             * since it is a struct and instantiation is requried each time we make changes
             * on motion*/
            prevDisplacement = displacement;
            displacement = new Point(0, 0);
            return prevDisplacement;      
        }
        public Point Revert()
        {
            return prevDisplacement;
        }
        public bool HitHidden(int dy)
        {
            if(yVelocity >= dy && prevDisplacement.Y < 0)
            {
                return true;
            }
            return false;
        }
        
    }
}
