using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftIdle : AbstractMovementState, IMarioMovementState
    {
        public LeftIdle(IMario mario)
        {
            this.mario = mario;
            mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
            this.mario.OnGround = true;
        }
        public override void Down()
        {
            mario.MovementState = new LeftCrouching(mario);
        }
        public override void Idle()
        {
            mario.Physics.SpeedDecay();
        }
        public override void Left()
        {        
            mario.MovementState  = new LeftMoving(mario);
        }
        public override void Right()
        {
            mario.MovementState = new RightIdle(mario); 
        }
        public override void Up()
        {
            if (mario.Physics.Jump) return;
            AudioFactory.Instance.CreateSound(StringConsts.Jump).Play();
            mario.MovementState = new LeftJumping(mario);
        }
        public override void Update(GameTime gameTime)
        {
            mario.Physics.SpeedDecay();
            base.Update(gameTime);
        }
    }
}
