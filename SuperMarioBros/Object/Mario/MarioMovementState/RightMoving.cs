using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightMoving : AbstractMovementState, IMarioMovementState
    {
        private readonly float jumpingSpeed = 40f;
        private bool movingRight = true;
        public RightMoving(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public override void Down()
        {
            if (!(mario.HealthState is SmallMario))
                mario.MovementState = new RightCrouching(mario);
        }

        public override void Right()
        {
            movingRight = true;
            mario.Physics.Right();
        }

        public override void Left()
        {
            mario.MovementState = new RightBreaking(mario);
        }

        public override void Up()
        {
            if (mario.Physics.Jump) return;
            AudioFactory.Instance.CreateSound("jump").Play();
            mario.MovementState = new RightJumping(mario);
        }

        public override void Idle()
        {
            movingRight = false;
        }
        public override void OnFireBall()
        {
            direction = FireBallDirection.right;
            offset = rightNormalOffSet;
            base.OnFireBall();
        }

        public override void Update(GameTime gameTime)
        {
            if (!movingRight)
            {
                mario.Physics.SpeedDecay();
                if (Math.Round(mario.Physics.Velocity.X) <= 0)
                    mario.MovementState = new RightIdle(mario);
            }
            if (mario.Physics.Velocity.Y >= jumpingSpeed)
            {
                mario.MovementState = new RightJumping(mario);
                mario.Physics.Jump = true;
                mario.Physics.JumpKeyUp = true;
            }
            base.Update(gameTime);
        }
        public override void SlidingFlagPole()
        {
            mario.Physics.CurrentGravity = 100f;
            mario.MovementState = new RightSliding(mario);
        }
    }
}
