using SuperMarioBros.Collisions;
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
            {
                mario.MovementState = new RightCrouching(mario);
            }
        }

        public void Right()
        {
            mario.MarioPhysics.Right();
        }

        public void Left()
        {
            mario.MovementState = new RightBreaking(mario);
        }

        public void Up()
        {
            mario.MovementState = new RightJumping(mario);
        }

        public void Update()
        {
            if (mario.MarioPhysics.Jump)
                mario.MovementState = new RightJumping(mario);
        }

        public void Idle()
        {
            mario.MarioPhysics.SpeedDecay();
            if (Math.Round(mario.MarioPhysics.XVelocity) <= 0)
            {
                mario.MovementState = new RightIdle(mario);
            }
        }

        public void MoveUp()
        {
            mario.MarioPhysics.MoveUp();
        }
    }
}
