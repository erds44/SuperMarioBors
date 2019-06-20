using SuperMarioBros.Collisions;
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
           mario.MarioPhysics.Left();
            mario.MarioPhysics.SpeedDecay();
        }


        public void Right()
        {
            mario.MarioPhysics.Right();
        }

        public void Up()
        {
            mario.MarioPhysics.Up();
        }

        public void MoveUp()
        {
            if (mario.MarioPhysics.Jump)
            {
                mario.MovementState = new LeftIdle(mario);
            }
            mario.MarioPhysics.SpeedDecay();
            mario.MarioPhysics.MoveUp();
        }
        public void Update()
        {
            // Do Nothing
        }
        public void BumpUp()
        {
            mario.MarioPhysics.BumpUp();
        }
    }
}
