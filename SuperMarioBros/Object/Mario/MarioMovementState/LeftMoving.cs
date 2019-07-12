using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;
using System;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftMoving : AbstractMovementState, IMarioMovementState
    {
        private bool movingLeft = true;
        public LeftMoving(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public override void Down()
        {
           mario.MovementState = new LeftCrouching(mario);
        }

        public override void Idle()
        {
            movingLeft = false;
        }

        public override void Left()
        {
            movingLeft = true;
            mario.Physics.Left();
        }

        public override void Right()
        {
            mario.MovementState = new LeftBreaking(mario);          
        }

        public override void Up()
        {
            if (mario.Physics.Jump) return;
            AudioFactory.Instance.CreateSound(StringConsts.Jump).Play();
            mario.MovementState = new LeftJumping(mario);
        }
        public override void Update(GameTime gameTime)
        {
            if (mario.Physics.Velocity.Y >= PhysicsConsts.MarioJumpingSpeed) 
            {
                mario.MovementState = new LeftJumping(mario);
                mario.Physics.Jump = true;
                mario.Physics.JumpKeyUp = true;
            }
            if (!movingLeft)
            {
                mario.Physics.SpeedDecay();
                if (Math.Round(mario.Physics.Velocity.X) >= 0)
                    mario.MovementState = new LeftIdle(mario);
            }
            base.Update(gameTime);
        }
    }
}
