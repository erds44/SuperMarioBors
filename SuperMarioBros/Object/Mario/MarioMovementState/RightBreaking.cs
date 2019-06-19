using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightBreaking : AbstractMovementState, IMarioMovementState
    {
        public RightBreaking(IMario mario)
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

        public void Idle()
        {
            mario.MarioPhysics.SpeedDecay();
            if (Math.Round(mario.MarioPhysics.XVelocity) <= 0)
            {
                mario.MovementState = new RightIdle(mario);
            }
        }

        public void Left()
        {
            if (Math.Round(mario.MarioPhysics.XVelocity) <= 0)
            {
                mario.MovementState = new LeftIdle(mario);
            }
            else
            {
                mario.MarioPhysics.Break();
            }
        }


        public void Right()
        {
            // mario.MovementState = new RightIdle(mario);
        }

        public void Up()
        {
            mario.MovementState = new RightJumping(mario);
        }

        public void MoveUp()
        {
            mario.MarioPhysics.MoveUp();
        }

        public void Update()
        {
            if (mario.MarioPhysics.YVelocity > 0)
                mario.MovementState = new RightJumping(mario);
        }
    }
}
