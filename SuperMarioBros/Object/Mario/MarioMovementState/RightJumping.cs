using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightJumping : AbstractMovementState, IMarioMovementState
    {
        private float maxRightJumpingHorizontalVelocity = 100f;
        public RightJumping(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }
        public void Down()
        {
           
        }

        public void Right()
        {
            mario.Physics.Right();
            if (mario.Physics.Velocity.X >= maxRightJumpingHorizontalVelocity)
                mario.Physics.Velocity = new Vector2(maxRightJumpingHorizontalVelocity, mario.Physics.Velocity.Y);
        }

        public void Left()
        {
           mario.Physics.Left();
        }

        public void Up()
        {
            mario.Physics.Up();
        }


        public void Idle()
        {
            
        }
        public override void OnGround()
        {
            mario.MovementState = new RightIdle(mario);
            base.OnGround();
        }
        public override void OnFireBall()
        {
            direction = fireBallDirection.right;
            offset = rightNormalOffSet;
            base.OnFireBall();
        }
    }
}
