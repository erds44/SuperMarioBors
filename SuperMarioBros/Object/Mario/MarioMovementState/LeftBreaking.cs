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

        public override void Down()
        {
            mario.MovementState = new LeftCrouching(mario);
        }

        public override void Idle()
        {
            mario.Physics.SpeedDecay();
            if (Math.Round(mario.Physics.Velocity.X) >= 0)
                mario.MovementState = new LeftIdle(mario);
        }

        public override void Right()
        {
            if (Math.Round(mario.Physics.Velocity.X) >= 0)
                mario.MovementState = new RightIdle(mario);
            else
                mario.Physics.Break();
        }
        public override void Left()
        {
            mario.MovementState = new LeftIdle(mario);
        }

        public override void Up()
        {
            if (!mario.Physics.Jump)
                mario.MovementState = new LeftJumping(mario);
        }
        public override void OnFireBall()
        {
            direction = FireBallDirection.right;
            offset = rightNormalOffSet;
            base.OnFireBall();
        }

    }
}
