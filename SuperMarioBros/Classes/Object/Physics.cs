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
        public Vector2 Position()
        {
            return position;
        }
    }
}
