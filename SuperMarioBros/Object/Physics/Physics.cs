using Microsoft.Xna.Framework;

namespace SuperMarioBros.Physicses
{
    public class Physics
    {
        private readonly int horizontalMotion;
        private readonly int verticalMotion;
        private Point motion;
        private Point prevMotion;
        public Physics(int horizontalMotion, int verticalMotion)
        {
            this.horizontalMotion = horizontalMotion;
            this.verticalMotion = verticalMotion;
            motion = new Point(0, 0);
        }
        public void Left()
        {
            motion.X -= horizontalMotion;
        }
        public void Right()
        {
            motion.X += horizontalMotion;
        }
        public void Up()
        {
            motion.Y -= verticalMotion;
        }
        public void Down()
        {
            motion.Y += verticalMotion;
        }
        public Point Motion()
        {
            /* If making motion as property, it will be tedious to make changes to motion
             * since it is a struct and instantiation is requried each time we make changes
             * on motion*/
            prevMotion = motion;
            motion = new Point(0, 0);
            return prevMotion;      
        }
        public Point Revert()
        {
            return prevMotion;
        }
        public int Direction()
        {
            return prevMotion.Y;
        }
        
    }
}
