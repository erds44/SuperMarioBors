using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.Marios;
using System;

namespace SuperMarioBros.Physicses
{
    public class MarioPhysics
    {
        public float XVelocity { get; private set; }
        public float YVelocity { get; private set; }
        private readonly float jumpVelocity = -420;
        private readonly float acceleration;
        private readonly float deceleration;
        private readonly float gravity = 800;
        private float currentGravity;
        private readonly float minClamping = -250;
        private readonly float maxClamping = 250;
        private float sprintVelocityRate;
        private Vector2 displacement;
        private Vector2 prevDisplacement;
        private float dt;
        public bool Jump { get; private set; }
        private readonly IMario mario;
        public MarioPhysics(IMario mario, int acceleration)
        {
            dt = 0;
            XVelocity = 0;
            YVelocity = 0;
            Jump = false;
            this.mario = mario;
            sprintVelocityRate = 1;
            currentGravity = gravity;
            prevDisplacement = displacement;
            displacement = new Vector2(0, 0);
            this.acceleration = acceleration;
            deceleration = (float)2 * acceleration;
        }
        public void Left()
        {
            XVelocity -= acceleration * dt;
        }
        public void Right()
        {
            XVelocity += acceleration * dt;
        }
        public void Up()
        {
            if (!Jump)
            {
                YVelocity += jumpVelocity;
                Jump = true;
            }
            currentGravity -= 20;
            if (currentGravity <= 300)
                currentGravity = 300;
        }
        /* Collision Responses */
        public void MoveUp()
        {
            mario.Position -= new Vector2(0, prevDisplacement.Y);
            YVelocity = 0;
            Jump = false;
            currentGravity = gravity; /* reset gravity because of jumping */
        }
        public void MoveDown()
        {
            mario.Position -= new Vector2(0, prevDisplacement.Y);
            YVelocity = -YVelocity;
        }
        public void MoveLeft()
        {
            mario.Position -= new Vector2(3 * prevDisplacement.X, 0);
            XVelocity = 0;
        }
        public void MoveRight()
        {
            mario.Position -= new Vector2(3 * prevDisplacement.X, 0);
            XVelocity = 0;
        }
        public void BumpUp()
        {
            YVelocity = -100;
        }
        /* help method in movementState */
        public void SpeedDecay()
        {
            XVelocity *= (float)0.96;
            Clamping();
        }
        private void Clamping()
        {
            if (Math.Floor(XVelocity) == 0)
            {
                XVelocity = 0;
            }
            if (XVelocity < minClamping)
            {
                XVelocity = minClamping;
            }
            else if (XVelocity > maxClamping)
            {
                XVelocity = maxClamping;
            }
        }
        public void Break()
        {
            XVelocity -= Math.Sign(XVelocity) * deceleration * dt;
        }
        public void SetSprintVelocityRate(float sprintVelocityRate)
        {
            this.sprintVelocityRate = sprintVelocityRate;
        }
        public void SetXVelocity(float xVelocity)
        {
            XVelocity = xVelocity;
        }
        public void SetYVelocity(float yVelocity)
        {
            YVelocity = yVelocity;
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
            if (YVelocity > 0)
            {
                YVelocity += (currentGravity + 200) * dt; /* make jumping downward faster */
                Jump = true;
            }
            else
            {
                YVelocity += currentGravity * dt;
            }
            displacement.X += (XVelocity * dt) * sprintVelocityRate;
            displacement.Y += (YVelocity * dt);
        }
    }
}
