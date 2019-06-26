using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftJumping : AbstractMovementState, IMarioMovementState
    {
        private float maxLeftJumpingHorizontalVelocity = -100f;
        public LeftJumping(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);           
        }

        public void Down()
        {

        }

        public void Idle()
        {
            
        }

        public void Left()
        {
           mario.Physics.Left();
            if (mario.Physics.Velocity.X <= maxLeftJumpingHorizontalVelocity)
                mario.Physics.Velocity = new Vector2(maxLeftJumpingHorizontalVelocity, mario.Physics.Velocity.Y);
        }


        public void Right()
        {
           mario.Physics.Right();
        }

        public void Up()
        {
            mario.Physics.Up();
        }

        public override void OnGround()
        {
            mario.MovementState = new LeftIdle(mario);
            base.OnGround();
        }

    }
}
