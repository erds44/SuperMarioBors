using SuperMarioBros.Collisions;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightCrouching : AbstractMovementState, IMarioMovementState
    { 
        public RightCrouching(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
           
        }

        public void Right()
        {

        }
        public void Left()
        {
            
        }

        public void Up()
        {
            // pHYSICS
        }
     
        //public void Update()
        //{
        //    // Do nothing.
        //}

        public void Idle()
        {
            mario.MovementState = new RightIdle(mario);
        }

        public void MoveUp()
        {
            mario.MarioPhysics.MoveUp();
        }

        public void Update()
        {
            if (mario.MarioPhysics.YVelocity > 0)
                mario.MovementState = new RightJumping(mario);
        }
    }
}
