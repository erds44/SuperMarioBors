using Microsoft.Xna.Framework;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftMoving : AbstractMovementState, IMarioMovementState
    {
        private readonly float jumpingSpeed = 40f;
        public LeftMoving(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public override void Down()
        {
            if (!(mario.HealthState is SmallMario))
                mario.MovementState = new LeftCrouching(mario);
        }

        public override void Idle()
        {
            mario.Physics.SpeedDecay();
            if (Math.Round(mario.Physics.Velocity.X) >= 0)
                mario.MovementState = new LeftIdle(mario);
        }

        public override void Left()
        {
            mario.Physics.Left();
        }


        public override void Right()
        {
            mario.MovementState = new LeftBreaking(mario);          
        }

        public override void Up()
        {
            if (!mario.Physics.Jump)
                mario.MovementState = new LeftJumping(mario);
        }
        public override void Update(GameTime gameTime)
        {
            if(mario.Physics.Velocity.Y >= jumpingSpeed) 
            {
                mario.MovementState = new LeftJumping(mario);
                mario.Physics.Jump = true;
                mario.Physics.JumpKeyUp = true;
            }
            base.Update(gameTime);
        }
    }
}
