using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightIdle : AbstractMovementState, IMarioMovementState
    {
        public RightIdle(IMario mario,Physics marioPhysics)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
            this.marioPhysics = marioPhysics;
        }

        public void Down()
        {
            if (!(mario.HealthState is SmallMario))
            {
                mario.MovementState = new RightCrouching(mario, marioPhysics);
            }
            else
            {
                marioPhysics.Down();
            }
        }

        public void Right()
        {
            mario.MovementState = new RightMoving(mario,  marioPhysics);
        }

        public void Left()
        {
            mario.MovementState = new LeftIdle(mario,marioPhysics);
        }

        public void Up()
        {
            mario.MovementState = new RightJumping(mario,  marioPhysics);
        }

        public void Update()
        {
            // Do Nothing
        }

        public void ChangeSprite()
        {
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Idle()
        {
            // Do Nothing
        }
    }
}
