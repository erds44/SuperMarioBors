using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using System;

namespace SuperMarioBros.Physicses
{
    public class Physics
    {
        public float XVelocity { get; private set; }
        public float YVelocity { get; private set; }
        private readonly float jumpVelocity = -50;
        private readonly float forwardAcceleration;
        private readonly float backwardAcceleration;
        private readonly float gravity;
        private readonly float minClamping = -200;
        private readonly float maxClamping = 200;
        public Direction CollisionDirection { get; set; }
        private Vector2 displacement;
        private Vector2 prevDisplacement;
        private float dt;
        private bool jump;
        public Physics(int forwardAcceleration)
        {
            this.forwardAcceleration = forwardAcceleration;
            this.backwardAcceleration = (float) 2 * forwardAcceleration;
            displacement = new Vector2(0, 0);
            prevDisplacement = displacement;
            dt = 0;
            XVelocity = 0;
            YVelocity = 0;
            gravity = 200;
            jump = false;
        }
        public void Left()
        {
            XVelocity -= forwardAcceleration * dt;
           
        }
        public void Right()
        {
            XVelocity += forwardAcceleration * dt;
           
        }
        public void Up()
        {
            if (!jump)
            {
                YVelocity += jumpVelocity;
                jump = true;
            }
        }
        public void SpeedDecay()
        {
            XVelocity *= (float)0.96;
        }
        public void BlockHorizontal()
        {
            XVelocity = 0;
        }

        public void BlockTop()
        {
            YVelocity *= -1;
        }
        public void BlockBottom()
        {
            if (YVelocity > 0)
            {
                YVelocity = 0;
            }
            jump = false;
        }
        public Vector2 Displacement(GameTime gameTime)
        {
            Update(gameTime);
            prevDisplacement = displacement;
            displacement = new Vector2(0, 0);                  
            return prevDisplacement;   
        }
        private void Obstacle()
        {
            if(CollisionDirection == Direction.bottom)
            {
                BlockTop();
            }else if(CollisionDirection == Direction.top)
            {
                BlockBottom();
            }else if(CollisionDirection == Direction.left || CollisionDirection == Direction.right)
            {
                BlockHorizontal();
            }
        }
        public bool HitHidden(int dy)
        {
            if(YVelocity >= dy && prevDisplacement.Y < 0)
            {
                return true;
            }
            return false;
        }

        private void Update(GameTime gameTime)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            YVelocity += gravity * dt;
            Clamping();
            Obstacle();
            displacement.X += (XVelocity * dt);
            displacement.Y += (YVelocity * dt);
            Console.WriteLine(CollisionDirection);
            CollisionDirection = Direction.none;
            
        }
        public void Break()
        {
            XVelocity -= Math.Sign(XVelocity) * backwardAcceleration * dt;
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

    }
}
