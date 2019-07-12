using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

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
            mario.Physics.CurrentGravity = PhysicsConsts.SlidingMarioGravity;
            mario.MovementState = new LeftSliding(mario);
        }
    }
}
