using Microsoft.Xna.Framework;
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
        }
        public void Down()
        {
           
        }

        public void Right()
        {
            mario.Physics.Right();
            
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
            direction = FireBallDirection.right;
            offset = rightNormalOffSet;
            base.OnFireBall();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void SlidingFlagPole()
        {
            mario.Physics.CurrentGravity = 100f;
            mario.MovementState = new RightSliding(mario);
        }
    }
}
