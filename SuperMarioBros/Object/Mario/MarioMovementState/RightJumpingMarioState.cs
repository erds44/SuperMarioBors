using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightJumpingMarioState : AbstractMovementState, IMarioMovementState
    {
        public RightJumpingMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightJumping"));
            this.marioPhysics = marioPhysics;
        }

        public void Down()
        {
            mario.ChangeMovementState(new RightIdleMarioState(mario, type, marioPhysics));
        }

        public void Right()
        {
            marioPhysics.Right();
        }

        public void Left()
        {
            // Do Nothing
        }

        public void Up()
        {
            marioPhysics.Up();
        }

        public void Update()
        {
            //marioPhysics.Up();
        }

        public void ChangeSprite(string type)
        { 
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightJumping"));
        }

        public void Idle()
        {
            mario.ChangeMovementState(new RightIdleMarioState(mario, type, marioPhysics));
        }
    }
}
