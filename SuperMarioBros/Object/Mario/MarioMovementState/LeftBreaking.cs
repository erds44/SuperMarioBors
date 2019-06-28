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
                mario.MovementState = new LeftCrouching(mario);
        }

        public void Idle()
        {
            mario.Physics.SpeedDecay();
            if (Math.Round(mario.Physics.Velocity.X) >= 0)
                mario.MovementState = new LeftIdle(mario);
        }

        public void Right()
        {
            if (Math.Round(mario.Physics.Velocity.X) >= 0)
                mario.MovementState = new RightIdle(mario);
            else
                mario.Physics.Break();
        }
        public void Left()
        {
            mario.MovementState = new LeftIdle(mario);
        }

        public void Up()
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
