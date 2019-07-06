using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightSliding : AbstractMovementState, IMarioMovementState
    {
        public RightSliding(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
            mario.Physics.Velocity = slidingVelocity;
        }

        public override void Right()
        {
            mario.MovementState = new RightMoving(mario);     
        }

        public override void ChangeSlidingDirection()
        {
            mario.Physics.CurrentGravity = 100f;
            mario.MovementState = new LeftSliding(mario);
        }
    }
}
