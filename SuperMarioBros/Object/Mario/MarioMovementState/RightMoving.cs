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
                mario.MovementState = new RightCrouching(mario);
        }

        public void Right()
        {
            mario.Physics.Right();
        }

        public void Left()
        {
            mario.MovementState = new RightBreaking(mario);
        }

        public void Up()
        {
            mario.MovementState = new RightJumping(mario);
        }

        public void Idle()
        {
            mario.Physics.SpeedDecay();
            if (Math.Round(mario.Physics.Velocity.X) <= 0)
            {
                mario.MovementState = new RightIdle(mario);
            }
        }
        public override void OnFireBall()
        {
            direction = fireBallDirection.right;
            offset = rightNormalOffSet;
            base.OnFireBall();
        }
    }
}
