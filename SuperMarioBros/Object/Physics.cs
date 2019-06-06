using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects
{
    public class Physics
    {
        private Point upMotion;
        private Point downMotion;
        private Point leftMotion;
        private Point rightMotion;
        private Point position;
        private Point prePosition;
        public Physics(Point upMotion, Point downMotion, Point leftMotion, Point rightMotion, Point position)
        {
            this.upMotion = upMotion;
            this.downMotion = downMotion;
            this.leftMotion = leftMotion;
            this.rightMotion = rightMotion;
            this.position = position;
        }
        public void Left()
        {
            if (position.X + leftMotion.X > 0)
            {
                position.X += leftMotion.X;
            }
        }
        public void Right()
        {
            if (position.X + rightMotion.X < 730)
            {
                position.X += rightMotion.X;
            }
        }
        public void Up()
        {
            if ( position.Y + upMotion.Y > 0)
            {
                position += upMotion;
            }
        }
        public void Down()
        {
            if (position.Y + downMotion.Y < 580)
            {
                position += downMotion;
            }
        }
        public Point Position()
        {
            prePosition = position;
            return position;
        }
        public int XPosition()
        {
            return (int)position.X;
        }
        public int YPosition()
        {
            return (int)position.Y;
        }
        public void Undo()
        {
            position = prePosition;
        }
    }
}
