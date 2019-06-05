using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightMovingMarioState : AbstractMovementState, IMarioMovementState
    {
        public RightMovingMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.marioPhysics = marioPhysics;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightMoving"));
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
            marioPhysics.Right();
        }

        public void Left()
        {
            mario.ChangeMovementState(new RightIdleMarioState(mario, type, marioPhysics));
        }

        public void Up()
        {
            mario.ChangeMovementState(new RightJumpingMarioState(mario, type, marioPhysics));
        }

        public void Update()
        {
            //marioPhysics.Right();
        }

        public void ChangeSprite(string type)
        {
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightMoving"));
        }

        public void Idle()
        {
            mario.ChangeMovementState(new RightIdleMarioState(mario, type, marioPhysics));
        }
    }
}
