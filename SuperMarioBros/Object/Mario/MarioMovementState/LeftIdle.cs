using SuperMarioBros.Collisions;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftIdle : AbstractMovementState, IMarioMovementState
    {
        public LeftIdle(IMario mario)
        {
            this.mario = mario;
            mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }


        public void Down()
        {
            if(!(mario.HealthState is SmallMario ))
            {
                mario.MovementState = new LeftCrouching(mario);
            }
        }

        public void Idle()
        {
            mario.MarioPhysics.SpeedDecay();
        }

        public void Left()
        {
            
            mario.MovementState  = new LeftMoving(mario);
        }


        public void Right()
        {
            mario.MovementState = new RightIdle(mario); 
        }

        public void Up()
        {
            mario.MovementState = new LeftJumping(mario);
        }

        public void MoveUp()
        {
            mario.MarioPhysics.MoveUp();
        }

        public void Update()
        {
            mario.MarioPhysics.setXVelocity(0);
        }
    }
}
