using Microsoft.Xna.Framework;

namespace SuperMarioBros.Classes.Object
{
    public class Physics
    {
        private Vector2 upMotion;
        private Vector2 downMotion;
        private Vector2 leftMotion;
        private Vector2 rightMotion;
        private Vector2 position;
        private Vector2 prePosition;
        public Physics(Vector2 upMotion, Vector2 downMotion, Vector2 leftMotion, Vector2 rightMotion, Vector2 position)
        {
            this.upMotion = upMotion;
            this.downMotion = downMotion;
            this.leftMotion = leftMotion;
            this.rightMotion = rightMotion;
            this.position = position;
        }
        public void Left()
        {
            prePosition = position;
            if (position.X + leftMotion.X > 0)
            {
                position.X += leftMotion.X;
            }
        }
        public void Right()
        {
            prePosition = position;
            if (position.X + rightMotion.X < 730)
            {
                position.X += rightMotion.X;
            }
        }
        public void Up()
        {
            prePosition = position;
            if ( position.Y + upMotion.Y > 0)
            {
                position += upMotion;
            }
        }
        public void Down()
        {
            prePosition = position;
            if (position.Y + downMotion.Y < 580)
            {
                position += downMotion;
            }
        }
        public Vector2 Position()
        {
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
