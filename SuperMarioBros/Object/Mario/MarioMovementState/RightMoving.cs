using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightMoving : AbstractMovementState, IMarioMovementState
    {
        public RightMoving(IMario mario, Physics marioPhysics)
        {
            this.mario = mario;
            this.marioPhysics = marioPhysics;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
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
            marioPhysics.Right();
        }

        public void Left()
        {
            mario.MovementState = new RightIdle(mario,marioPhysics);
        }

        public void Up()
        {
            mario.MovementState = new RightJumping(mario, marioPhysics);
        }

        public void Update()
        {
            //marioPhysics.Right();
        }

        public void Idle()
        {
            mario.MovementState = new RightIdle(mario,marioPhysics);
        }
    }
}
