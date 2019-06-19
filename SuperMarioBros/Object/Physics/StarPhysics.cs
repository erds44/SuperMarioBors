using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Physicses
{
    public class StarPhysics
    {
        private Vector2 velocity;
        private readonly float gravity = 120;
        private Vector2 displacement;
        private Vector2 prevDisplacement;
        private float dt = 0;
        private readonly IObject obj;
        private float currentGravity;
        public StarPhysics(IObject obj, Vector2 velocity)
        {
            this.velocity = velocity;
            this.obj = obj;
            displacement = new Vector2(0, 0);
            prevDisplacement = displacement;
            currentGravity = 0;
        }
        public void MoveUp()
        {
            obj.Position -= new Vector2(0, prevDisplacement.Y);
            velocity.Y *= -1;
        }
        public void MoveLeft()
        {
            obj.Position -= new Vector2(3*prevDisplacement.X, 0);
            velocity.X *= -1;
        }
        public void MoveRight()
        {
            obj.Position -= new Vector2(3*prevDisplacement.X, 0);
            velocity.X *= -1;
        }
        public void MoveDown()
        {
            obj.Position -= new Vector2(0, prevDisplacement.Y);
            velocity.Y *= -1;
        }

        public Vector2 Displacement(GameTime gameTime)
        {
            Update(gameTime);
            prevDisplacement = displacement;
            displacement = new Vector2(0, 0);                  
            return prevDisplacement;   
        }

        private void Update(GameTime gameTime)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity.Y += currentGravity * dt;
            displacement.X += (velocity.X * dt);
            displacement.Y += (velocity.Y * dt);          
        }

        public void SetSpeed(Vector2 velocity)
        {
            this.velocity = velocity;
            currentGravity = gravity;
        }
        public void ChangeDirection()
        {
            velocity.X *= -1;
        }
        public void BumpUp()
        {
            displacement.Y -= 20;
            velocity.Y -= 20;
        }
    }
}
