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
                mario.MovementState = new RightCrouching(mario);
        }

        public void Idle()
        {
            mario.Physics.SpeedDecay();
            if (Math.Round(mario.Physics.Velocity.X) <= 0)
                mario.MovementState = new RightIdle(mario);
        }

        public void Left()
        {
            if (Math.Round(mario.Physics.Velocity.X) <= 0)
                mario.MovementState = new LeftIdle(mario);
            else
                mario.Physics.Break();
        }


        public void Right()
        {
             mario.MovementState = new RightIdle(mario);
        }

        public void Up()
        {
            if (!mario.Physics.Jump)
                mario.MovementState = new RightJumping(mario);
        }
        public override void SlidingFlagPole()
        {
            mario.MovementState = new RightSliding(mario);
        }

    }
}
