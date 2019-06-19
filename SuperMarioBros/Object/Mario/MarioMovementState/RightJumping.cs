using SuperMarioBros.Collisions;
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
            mario.MarioPhysics.Right();
            mario.MarioPhysics.SpeedDecay();
        }

        public void Left()
        {
            mario.MarioPhysics.Left();
        }

        public void Up()
        {
            mario.MarioPhysics.Up();
        }


        public void Idle()
        {
            
        }

        public void MoveUp()
        {

            if (mario.MarioPhysics.Jump)
            {
                mario.MovementState = new RightIdle(mario);
            }
            mario.MarioPhysics.MoveUp();
        }
    }
}
