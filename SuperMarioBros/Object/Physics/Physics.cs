using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Physicses
{
    public class Physics
    {
        private float dt = 0f;
        private float gravity;
        private const float DECAYRATIO = 0.96f;
        private float currentGravity;
        private Vector2 displacement = Vector2.Zero;
        private float sprintVelocityRate;
        private float weight;
        private float acceleration = 0f;
        private float deceleration = 0f;
        public  Vector2 Velocity {get; set;}
        public bool Jump {get; set;}
        private float gravityDecrement = 20f;
        private float minGravity = 280f;
        private readonly float maxClamping = 250f;
        private readonly float minClamping = -250f;
        private readonly float jumpVelocity = -450f;
        public Physics(Vector2 velocity, float gravity, float weight, float acceleration = 0) /* For Mario */
        {
            Velocity = velocity;
            Jump = false;
            sprintVelocityRate = 1f;
            currentGravity = 0f;
            this.weight = weight;
            this.acceleration = acceleration;
            deceleration = 2f * acceleration;
            this.gravity = gravity;
        }
 
        public void Left()
        {
            Velocity -= new Vector2 (acceleration * dt, 0);
        }
        public void Right()
        {
            Velocity += new Vector2(acceleration * dt, 0);
        }
        public void Up()
        {
            if (!Jump)
            {
                Velocity = new Vector2(Velocity.X, jumpVelocity);
                Jump = true;
            }
            currentGravity -= gravityDecrement;
            if (currentGravity <= minGravity)
                currentGravity = minGravity;
        }
        public void ApplyGravity()
        {
            currentGravity = gravity;
        }
        public void SetGravity(float gravity)
        {
            currentGravity = gravity;
        }
        public void SpeedDecay()
        {
            Velocity = new Vector2(Velocity.X * DECAYRATIO, Velocity.Y);
            if (Math.Floor(Velocity.X) == 0)
                Velocity = new Vector2(0, Velocity.Y);
            if (Velocity.X < minClamping)
                Velocity = new Vector2(minClamping, Velocity.Y);
            else if (Velocity.X > maxClamping)
                Velocity = new Vector2(maxClamping, Velocity.Y);
        }
        public void Break()
        {
            Velocity = new Vector2 (Velocity.X - Math.Sign(Velocity.X) * deceleration * dt, Velocity.Y);
        }
        public void SetSprintVelocityRate(float sprintVelocityRate)
        {
            this.sprintVelocityRate = sprintVelocityRate;
        }
        public Vector2 Displacement(GameTime gameTime)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Velocity.Y > 0)
                Velocity = new Vector2(Velocity.X, Velocity.Y + (currentGravity + weight) * dt); /* make jumping downward faster */
            else
                Velocity = new Vector2(Velocity.X, Velocity.Y + currentGravity * dt);
            displacement = Vector2.Zero;
            displacement.X += (Velocity.X * dt) * sprintVelocityRate;
            displacement.Y += (Velocity.Y * dt);
            return displacement;
        }
    }
}
