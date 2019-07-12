using Microsoft.Xna.Framework;
using SuperMarioBros.Utility;
using System;

namespace SuperMarioBros.Physicses
{
    public class Physics
    {
        private float dt = Timers.InitialTime;
        private readonly float gravity;
        private const float DECAYRATIO = PhysicsConsts.DecayRatio;
        public  float CurrentGravity{get;set;}
        private Vector2 displacement = Vector2.Zero;
        private float sprintVelocityRate;
        private readonly float weight;
        private float currentWeight;
        private readonly float acceleration;
        private readonly float deceleration;
        public Vector2 Velocity {get; set;}
        public bool Jump {get; set;}
        public bool JumpKeyUp { get; set; }
        private readonly float gravityDecrement = PhysicsConsts.GravityDecrement;
        private readonly float minGravity = PhysicsConsts.MinGravity;
        private readonly float maxClamping = PhysicsConsts.MaxClamping;
        private readonly float minClamping = PhysicsConsts.MinClamping;
        private readonly float jumpVelocity = PhysicsConsts.JumpVelocity;
        public Physics(Vector2 velocity, float gravity, float weight, float acceleration = PhysicsConsts.DefaultAccelaration) 
        {
            Velocity = velocity;
            Jump = false;
            sprintVelocityRate = PhysicsConsts.DefaultSprintVelocityRate;     // used for x speed up, by calling set spirnt speed method
            CurrentGravity = PhysicsConsts.ZeroGravity;         // it does not actually boost speed but increse displacement, since if x is KeyUp, we
            this.weight = weight;        // wish to see the speed goes back to original state
            currentWeight = weight;
            this.acceleration = acceleration;
            deceleration = PhysicsConsts.DecelarationScale * acceleration;
            this.gravity = gravity;
            JumpKeyUp = false;
        }
        public void Left()
        {
            Velocity -= new Vector2 (acceleration * dt, PhysicsConsts.ZeroVelocity);
        }
        public void Right()
        {
            Velocity += new Vector2(acceleration * dt, PhysicsConsts.ZeroVelocity);
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
            if(acceleration != PhysicsConsts.DefaultAccelaration)
                Clamping();
            displacement = Vector2.Zero;
            displacement.X += (Velocity.X * dt * sprintVelocityRate);
            displacement.Y += (Velocity.Y * dt);
            return displacement;
        }
        private void Clamping()
        {
            if (Math.Floor(Velocity.X) == 0)
                Velocity = new Vector2(PhysicsConsts.ZeroVelocity, Velocity.Y);
            if (Velocity.X < minClamping)
                Velocity = new Vector2(minClamping, Velocity.Y);
            else if (Velocity.X > maxClamping)
                Velocity = new Vector2(maxClamping, Velocity.Y);
        }
        public void SetConstentVelocity(Vector2 velocity)
        {
            currentWeight = PhysicsConsts.ZeroWeight;
            CurrentGravity = PhysicsConsts.ZeroGravity;
            sprintVelocityRate = PhysicsConsts.DefaultSprintVelocityRate;
            Velocity = velocity;
        }

        public void ResetVelocity()
        {
            Velocity = Vector2.Zero;
            CurrentGravity = gravity;
        }
    }
}
