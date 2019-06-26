using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftJumping : AbstractMovementState, IMarioMovementState
    {
        public LeftJumping(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);           
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
           mario.Physics.SpeedDecay();
        }


        public void Right()
        {
            mario.Physics.Right();
            mario.Physics.SpeedDecay();
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
    }
}
