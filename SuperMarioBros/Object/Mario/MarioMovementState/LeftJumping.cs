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
            AudioFactory.Instance.CreateSound("jump").Play();
        }

        public override void Left()
        {
            mario.Physics.Left();
        }


        public override void Right()
        {
           mario.Physics.Right();
        }

        public override void Up()
        {
            mario.Physics.Up();
        }

        public override void OnGround()
        {
            mario.MovementState = new LeftIdle(mario);
            base.OnGround();
        }

    }
}
