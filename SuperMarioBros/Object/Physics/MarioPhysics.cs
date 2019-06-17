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
        private readonly float jumpVelocity = -230;
        private readonly float forwardAcceleration;
        private readonly float backwardAcceleration;
        private readonly float gravity;
        private readonly float minClamping = -200;
        private readonly float maxClamping = 200;
        private Vector2 displacement;
        private Vector2 prevDisplacement;
        private float dt;
        public bool Jump { get; private set; }
        private readonly IMario mario;
        public MarioPhysics(IMario mario, int forwardAcceleration)
        {
            this.forwardAcceleration = forwardAcceleration;
            this.backwardAcceleration = (float) 2 * forwardAcceleration;
            displacement = new Vector2(0, 0);
            prevDisplacement = displacement;
            dt = 0;
            XVelocity = 0;
            YVelocity = 0;
            gravity = 200;
            Jump = false;
            this.mario = mario;
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
            if (!Jump)
            {
                YVelocity += jumpVelocity;
                Jump = true;
            }
        }
        public void MoveUp()
        {
            mario.Position -= new Vector2(0, prevDisplacement.Y);
            YVelocity = 0;
            Jump = false;
        }
        public void MoveDown()
        {
            mario.Position -= new Vector2(0, prevDisplacement.Y);
             YVelocity *= -1;
        }
        public void MoveLeft()
        {
            mario.Position -= new Vector2(3*prevDisplacement.X, 0);
            XVelocity = 0;
        }
        public void MoveRight()
        {
            mario.Position -= new Vector2(3*prevDisplacement.X, 0);
            XVelocity = 0;
        }
        public void SpeedDecay()
        {
            XVelocity *= (float)0.96;
            Clamping();
        }

        public Vector2 Displacement(GameTime gameTime)
        {
            Update(gameTime);
            prevDisplacement = displacement;
            displacement = new Vector2(0, 0);                  
            return prevDisplacement;   
        }

        public bool HitHidden(int dy)
        {
            if(YVelocity * dt >= dy && prevDisplacement.Y < 0)
            {
                return true;
            }
            return false;
        }

        private void Update(GameTime gameTime)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            YVelocity += gravity * dt;
            displacement.X += (XVelocity * dt);
            displacement.Y += (YVelocity * dt);          
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
