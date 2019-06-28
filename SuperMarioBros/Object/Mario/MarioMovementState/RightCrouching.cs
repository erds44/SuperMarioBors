using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightCrouching : AbstractMovementState, IMarioMovementState
    { 
        public RightCrouching(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
           
        }

        public void Right()
        {

        }
        public void Left()
        {
            
        }

        public void Up()
        {
            mario.MovementState = new RightIdle(mario);
        }

        public void Idle()
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
    }
}
