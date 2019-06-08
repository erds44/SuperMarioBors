using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightIdleMarioState : AbstractMovementState, IMarioMovementState
    {
        public RightIdleMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightIdle"));
            this.marioPhysics = marioPhysics;
        }

        public void Down()
        {
            if (!type.Equals("SmallMario"))
            {
                mario.ChangeMovementState(new RightCrouchingMarioState(mario, type, marioPhysics));
            }
            else
            {
                marioPhysics.Down();
            }
        }

        public void Right()
        {
            mario.ChangeMovementState(new RightMovingMarioState(mario, type, marioPhysics));
        }

        public void Left()
        {
            mario.ChangeMovementState(new LeftIdleMarioState(mario, type, marioPhysics));
        }

        public void Up()
        {
            mario.ChangeMovementState(new RightJumpingMarioState(mario, type, marioPhysics));
        }

        public void Update()
        {
            // Do Nothing
        }

        public void ChangeSprite(string type)
        {
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightIdle"));
        }

        public void Idle()
        {
            // Do Nothing
        }
    }
}
