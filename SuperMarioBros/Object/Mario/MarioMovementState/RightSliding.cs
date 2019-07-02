using Microsoft.Xna.Framework;
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

        public void Down()
        {
            //Do Nothing
        }

        public void Idle()
        {
            //Do Nothing
        }

        public void Left()
        {
            //Do Nothing
        }


        public void Right()
        {
            mario.MovementState = new RightMoving(mario);     
        }

        public void Up()
        {
            //Do Nothing
        }
        public override void Update(GameTime gameTime)
        {
            //Do Nothing
        }
        public override void SlidingFlagPole()
        {
            // Do Nothing
        }
        public override void ChangeSlidingDirection()
        {
            mario.MovementState = new LeftSliding(mario);
        }
    }
}
