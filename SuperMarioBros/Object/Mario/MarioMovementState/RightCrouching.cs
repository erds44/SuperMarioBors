using Microsoft.Xna.Framework;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightCrouching : AbstractMovementState, IMarioMovementState
    { 
        public RightCrouching(IMario mario)
        {
            this.mario = mario;
            if(mario.HealthState is SmallMario)
                this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + nameof(RightIdle));
            else
                this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public override void Up()
        {
            mario.MovementState = new RightIdle(mario);
        }

        public override void Idle()
        {
            mario.MovementState = new RightIdle(mario);
        }

        public override void Update(GameTime gameTime)
        {
            mario.Physics.SpeedDecay();
            base.Update(gameTime);
        }
        public override void OnFireBall()
        {
            direction = FireBallDirection.right;
            offset = rightCrouchingOffset;
            base.OnFireBall();
        }
        public override void SlidingFlagPole()
        {
            mario.Physics.CurrentGravity = 100f;
            mario.MovementState = new RightSliding(mario);
        }
    }
}
