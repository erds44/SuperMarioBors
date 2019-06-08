using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftIdle : AbstractMovementState, IMarioMovementState
    {
        public LeftIdle(IMario mario,  Physics marioPhysics)
        {
            this.mario = mario;
            this.marioPhysics = marioPhysics;
            mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void ChangeSprite()
        {
            string type = mario.HealthState.GetType().Name;
            mario.Sprite = SpriteFactory.CreateSprite(type + GetType().Name);
        }

        public void Down()
        {
            if(!(mario.HealthState is SmallMario ))
            {
                mario.MovementState = new LeftCrouching(mario, marioPhysics);
            }
            else
            {
                marioPhysics.Down();
            }
        }

        public void Idle()
        {
            // Do Nothing
        }

        public void Left()
        {
            
            mario.MovementState  = new LeftMoving(mario,marioPhysics);
        }


        public void Right()
        {
            mario.MovementState = new RightIdle(mario,marioPhysics); 
        }

        public void Up()
        {
            mario.MovementState = new LeftJumping(mario,marioPhysics);
        }

        public void Update()
        {
            // Do nothing
        }
    }
}
