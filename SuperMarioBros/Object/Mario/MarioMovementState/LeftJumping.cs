using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftJumping : AbstractMovementState, IMarioMovementState
    {
        public LeftJumping(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
            this.mario.OnGround = false;
        }

        public void Down()
        {

        }

        public void Idle()
        {
            
        }

        public void Left()
        {
            mario.Physics.Left();
        }


        public void Right()
        {
           mario.Physics.Right();
        }

        public void Up()
        {
            mario.Physics.Up();
        }

        public override void OnGround()
        {
            mario.MovementState = new LeftIdle(mario);
            base.OnGround();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
