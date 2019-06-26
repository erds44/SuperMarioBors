using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightJumping : AbstractMovementState, IMarioMovementState
    {
        public RightJumping(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }
        public void Down()
        {
           
        }

        public void Right()
        {
            mario.Physics.Right();
            mario.Physics.SpeedDecay();
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
    }
}
