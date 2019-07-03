using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Physicses
{
    public class Physics
    {
        private float dt = 0f;
        private readonly float gravity;
        private const float DECAYRATIO = 0.96f;
        public  float CurrentGravity{get;set;}
        private Vector2 displacement = Vector2.Zero;
        private float sprintVelocityRate;
        private readonly float weight;
        private float currentWeight;
        private readonly float acceleration = 0f;
        private readonly float deceleration = 0f;
        public Vector2 Velocity {get; set;}
        public bool Jump {get; set;}
        public bool JumpKeyUp { get; set; }
        private readonly float gravityDecrement = 20f;
        private readonly float minGravity = 280f;
        private readonly float maxClamping = 200f;
        private readonly float minClamping = -200f;
        private readonly float jumpVelocity = -450f;
        public Physics(Vector2 velocity, float gravity, float weight, float acceleration = 0) 
        {
            Velocity = velocity;
            Jump = false;
            sprintVelocityRate = 1f;     // used for x speed up, by calling set spirnt speed method
            CurrentGravity = 0f;         // it does not actually boost speed but increse displacement, since if x is KeyUp, we
            this.weight = weight;        // wish to see the speed goes back to original state
            currentWeight = weight;
            this.acceleration = acceleration;
            deceleration = 2f * acceleration;
            this.gravity = gravity;
            JumpKeyUp = false;
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
            CurrentGravity -= gravityDecrement;
            if (CurrentGravity <= minGravity)
                CurrentGravity = minGravity;
        }
        public void ApplyGravity()
        {
            CurrentGravity = gravity;
            currentWeight = weight;
        }
        public void SpeedDecay()
        {
            Velocity = new Vector2(Velocity.X * DECAYRATIO, Velocity.Y);
        }
        public void Break()
        {
            Velocity = new Vector2 (Velocity.X - Math.Sign(Velocity.X) * deceleration * dt, Velocity.Y);
        }
        public void SetSprintVelocityRate(float inputSprintVelocityRate)
        {
            this.sprintVelocityRate = inputSprintVelocityRate;
        }
        public Vector2 Displacement(GameTime gameTime)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Velocity.Y > 0)
                Velocity = new Vector2(Velocity.X, Velocity.Y + (CurrentGravity + currentWeight) * dt); /* make jumping downward faster */
            else
                Velocity = new Vector2(Velocity.X, Velocity.Y + CurrentGravity * dt);
            Clamping();
            displacement = Vector2.Zero;
            displacement.X += (Velocity.X * dt * sprintVelocityRate);
            displacement.Y += (Velocity.Y * dt);
            return displacement;
        }
        private void Clamping()
        {
            if (Math.Floor(Velocity.X) == 0)
                Velocity = new Vector2(0, Velocity.Y);
            if (Velocity.X < minClamping)
                Velocity = new Vector2(minClamping, Velocity.Y);
            else if (Velocity.X > maxClamping)
                Velocity = new Vector2(maxClamping, Velocity.Y);
        }
        public void SetConstentVelocity(Vector2 velocity)
        {
            CurrentGravity = -200f;
            Velocity = velocity;
        }
    }
}
