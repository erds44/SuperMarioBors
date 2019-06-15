using SuperMarioBros.Collisions;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftBreaking : AbstractMovementState, IMarioMovementState
    {
        public LeftBreaking(IMario mario)
        {
            this.mario = mario;
            mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
            if (!(mario.HealthState is SmallMario))
            {
                mario.MovementState = new LeftCrouching(mario);
            }
        }

        public void Idle()
        {
            if (Math.Round(mario.MarioPhysics.XVelocity) >= 0)
            {
                mario.MovementState = new LeftIdle(mario);
            }
            else
            {
                mario.MarioPhysics.SpeedDecay();
            }
        }

        public void Right()
        {
            if (Math.Round(mario.MarioPhysics.XVelocity) >= 0)
            {
                mario.MovementState = new RightIdle(mario);
            }
            else
            {
                mario.MarioPhysics.Break();
            }
        }
        public void Left()
        {
            mario.MovementState = new LeftIdle(mario);
        }

        public void Up()
        {
            mario.MovementState = new LeftJumping(mario);
        }

        public void Obstacle(Direction direction)
        {
            if(direction == Direction.right)
            {
                mario.MovementState = new LeftIdle(mario);
            }
        }
    }
}
