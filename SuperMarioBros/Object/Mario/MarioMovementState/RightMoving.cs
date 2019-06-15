using SuperMarioBros.Collisions;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightMoving : AbstractMovementState, IMarioMovementState
    {
        public RightMoving(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
            if (!(mario.HealthState is SmallMario))
            {
                mario.MovementState = new RightCrouching(mario);
            }
        }

        public void Right()
        {
            mario.MarioPhysics.Right();
        }

        public void Left()
        {
            mario.MovementState = new RightBreaking(mario);
        }

        public void Up()
        {
            mario.MovementState = new RightJumping(mario);
        }

        public void Update()
        {

        }

        public void Idle()
        {
            if (Math.Round(mario.MarioPhysics.XVelocity) <= 0)
            {
                mario.MovementState = new RightIdle(mario);
            }
            else
            {
                mario.MarioPhysics.SpeedDecay();
            }
        }

        public void Obstacle(Direction direction)
        {
            
        }
    }
}
