using Microsoft.Xna.Framework;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightIdle : AbstractMovementState, IMarioMovementState
    {
        public RightIdle(IMario mario)
        {
           this.mario = mario;
           this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
            if (!(mario.HealthState is SmallMario))
                mario.MovementState = new RightCrouching(mario);
        }

        public void Right()
        {
              mario.MovementState = new RightMoving(mario);
        }

        public void Left()
        {
             mario.MovementState = new LeftIdle(mario);
        }

        public void Up()
        {
            if (!mario.Physics.Jump)
                mario.MovementState = new RightJumping(mario);
        }

        public void Idle()
        {
            mario.Physics.SpeedDecay();
        }

        public override void Update(GameTime gameTime)
        {
            mario.Physics.SpeedDecay();
            base.Update(gameTime);
        }
        public override void OnFireBall()
        {
            direction = FireBallDirection.right;
            offset = rightNormalOffSet;
            base.OnFireBall();
        }
    }
}
