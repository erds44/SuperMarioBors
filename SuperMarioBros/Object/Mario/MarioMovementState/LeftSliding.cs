using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftSliding : AbstractMovementState, IMarioMovementState
    {
        public LeftSliding(IMario mario)
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
            mario.MovementState = new RightSliding(mario);
        }
    }
}
