using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;
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

        public override void Down()
        {
            mario.MovementState = new RightCrouching(mario);
        }

        public override void Idle()
        {
            mario.Physics.SpeedDecay();
            if (Math.Round(mario.Physics.Velocity.X) <= 0)
                mario.MovementState = new RightIdle(mario);
        }

        public override void Left()
        {
            if (Math.Round(mario.Physics.Velocity.X) <= 0)
                mario.MovementState = new LeftIdle(mario);
            else
                mario.Physics.Break();
        }


        public override void Right()
        {
             mario.MovementState = new RightIdle(mario);
        }

        public override void Up()
        {
            if (!mario.Physics.Jump)
                mario.MovementState = new RightJumping(mario);
        }
        public override void SlidingFlagPole()
        {
            mario.Physics.CurrentGravity = PhysicsConsts.SlidingMarioGravity;
            mario.MovementState = new RightSliding(mario);
        }
    }
}
