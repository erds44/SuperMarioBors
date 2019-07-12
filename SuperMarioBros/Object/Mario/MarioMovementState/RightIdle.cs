using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightIdle : AbstractMovementState, IMarioMovementState
    {
        public RightIdle(IMario mario)
        {
           this.mario = mario;
           this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
           this.mario.OnGround = true;
        }

        public override void Down()
        {
            mario.MovementState = new RightCrouching(mario);
        }

        public override void Right()
        {
              mario.MovementState = new RightMoving(mario);
        }

        public override void Left()
        {
             mario.MovementState = new LeftIdle(mario);
        }

        public override void Up()
        {
            if (mario.Physics.Jump) return;
            AudioFactory.Instance.CreateSound(Strings.Jump).Play();
            mario.MovementState = new RightJumping(mario);
        }

        public override void Idle()
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
        public override void SlidingFlagPole()
        {
            mario.Physics.CurrentGravity = PhysicsConsts.SlidingMarioGravity;
            mario.MovementState = new RightSliding(mario);
        }
    }
}
