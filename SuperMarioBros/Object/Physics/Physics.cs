using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Physicses
{
    public class Physics
    {
        private int xVelocity = 0;
        private int yVelocity = 0;
        private readonly int forwardAcceleration;
        private readonly int backwardAcceleration = 1;
        private readonly int gravity;
        private readonly int minClamping = -3;
        private readonly int maxClamping = 3;
        private Point displacement;
        private Point prevDisplacement;
        private int count;
        public Physics(int forwardAcceleration)
        {
            this.forwardAcceleration = forwardAcceleration;
            displacement = new Point(0, 0);
            count = 0;
        }
        public void Left()
        {
            if(count % 5 == 0)
            {
                xVelocity -= (forwardAcceleration - backwardAcceleration);
                count = 0;
            }
           
        }
        public void Right()
        {
            if(count % 5 == 0)
            {
                xVelocity += (forwardAcceleration - backwardAcceleration);
                count = 0;
            }
           
        }
        public void Up()
        {
            
        }
        public void Down()
        {
            
        }
        public Point Displacement()
        {
            /* If making motion as property, it will be tedious to make changes to motion
             * since it is a struct and instantiation is requried each time we make changes
             * on motion*/
            Update();
            prevDisplacement = displacement;
            displacement = new Point(0, 0);
            return prevDisplacement;      
        }
        public Point Revert()
        {
            return prevDisplacement;
        }
        public bool HitHidden(int dy)
        {
            if(yVelocity >= dy && prevDisplacement.Y < 0)
            {
                return true;
            }
            return false;
        }
        public void SpeedDecay()
        {
            if( count % 5 == 0)
            {
                xVelocity = (int)((float)xVelocity * 0.6);
            }
        }
        private void Update()
        {
            if(xVelocity > 0)
            {
                Console.WriteLine(xVelocity);
            }
            if (xVelocity < minClamping)
            {
                xVelocity = minClamping;
            }
            else if (xVelocity > maxClamping)
            {
                xVelocity = maxClamping;
            }
            displacement.X += xVelocity;
            count++;
        }
        private void Break()
        {
            xVelocity = (Math.Abs(xVelocity) - backwardAcceleration) * Math.Sign(xVelocity);
        }
    }
}
