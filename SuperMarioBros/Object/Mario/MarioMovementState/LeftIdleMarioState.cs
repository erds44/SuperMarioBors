using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{ 
    public class LeftIdleMarioState : AbstractMovementState, IMarioMovementState
    {
        public LeftIdleMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.marioPhysics = marioPhysics;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftIdle"));
        }

        public void ChangeSprite(string type)
        {
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftIdle"));
        }

        public void Down()
        {
            if(!(type.Equals("SmallMario") ))
            {
                mario.ChangeMovementState(new LeftCrouchingMarioState(mario, type, marioPhysics));
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
            
            mario.ChangeMovementState(new LeftMovingMarioState(mario, type, marioPhysics));
        }


        public void Right()
        {
            mario.ChangeMovementState(new RightIdleMarioState(mario, type, marioPhysics)); 
        }

        public void Up()
        {
            mario.ChangeMovementState(new LeftJumpingMarioState(mario, type, marioPhysics));
        }

        public void Update()
        {
            // Do nothing
        }
    }
}
