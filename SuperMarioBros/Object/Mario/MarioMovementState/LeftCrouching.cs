using Microsoft.Xna.Framework;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftCrouching : AbstractMovementState,IMarioMovementState
    {
        public LeftCrouching(IMario mario)
        {
            this.mario = mario;
            if (mario.HealthState is SmallMario)
                this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + nameof(LeftIdle));
            else
                this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }
        public override void Idle()
        {
            mario.MovementState = new LeftIdle(mario);
        }
        public override void Up()
        {
            mario.MovementState = new LeftIdle(mario);
        }
        public override void Update(GameTime gameTime)
        {
            mario.Physics.SpeedDecay();
            offset = leftCrouchingOffset;
            base.Update(gameTime);
        }

    }
}
