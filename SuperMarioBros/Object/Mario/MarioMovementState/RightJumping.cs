using SuperMarioBros.AudioFactories;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightJumping : AbstractMovementState, IMarioMovementState
    {
        public RightJumping(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
            this.mario.OnGround = false;
            AudioFactory.Instance.CreateSound("jump").Play();
        }

        public override void Right()
        {
            mario.Physics.Right();           
        }

        public override void Left()
        {
           mario.Physics.Left();
        }

        public override void Up()
        {
            mario.Physics.Up();
        }

        public override void OnGround()
        {
            mario.MovementState = new RightIdle(mario);
            base.OnGround();
        }
        public override void OnFireBall()
        {
            direction = FireBallDirection.right;
            offset = rightNormalOffSet;
            base.OnFireBall();
        }
        public override void SlidingFlagPole()
        {
            mario.Physics.CurrentGravity = 100f;
            mario.MovementState = new RightSliding(mario);
        }
    }
}
