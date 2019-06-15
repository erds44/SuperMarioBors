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
        }

        public void Left()
        {
            mario.MarioPhysics.Left();
        }

        public void Up()
        {
            mario.MarioPhysics.Up();
        }

        //public void Update()
        //{
        //    //marioPhysics.Up();
        //}


        public void Idle()
        {
            
        }

        public void Obstacle(Direction direction)
        {
            if (direction == Direction.top && mario.MarioPhysics.YVelocity > 0)
            {
                mario.MovementState = new RightIdle(mario);
            }
        }
    }
}
