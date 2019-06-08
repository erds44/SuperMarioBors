using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftMoving : AbstractMovementState, IMarioMovementState
    {
        public LeftMoving(IMario mario, Physics marioPhysics)
        {
            this.mario = mario;
            this.marioPhysics = marioPhysics;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void ChangeSprite()
        {
            mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
            if (!(mario.HealthState is SmallMario))
            {
                mario.MovementState = new LeftCrouching(mario,marioPhysics);
            }
            else
            {
                marioPhysics.Down();
            }
        }

        public void Idle()
        {
            mario.MovementState = new LeftIdle(mario,marioPhysics);
        }

        public void Left()
        {
            marioPhysics.Left();
        }

        public void Right()
        {
            mario.MovementState = new LeftIdle(mario,marioPhysics);
        }

        public void Up()
        {
            mario.MovementState = new LeftJumping(mario,marioPhysics);
        }

        public void Update()
        {
            //marioPhysics.Left();
        }
    }
}
