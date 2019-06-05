using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftJumpingMarioState : AbstractMovementState, IMarioMovementState
    {
        public LeftJumpingMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.marioPhysics = marioPhysics;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftJumping"));
            
        }

        public void ChangeSprite(string type)
        {
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftJumping"));
        }

        public void Down()
        {
            mario.ChangeMovementState(new LeftIdleMarioState(mario,type, marioPhysics));
        }

        public void Idle()
        {
            mario.ChangeMovementState(new LeftIdleMarioState(mario, type, marioPhysics));
        }

        public void Left()
        {
           marioPhysics.Left();
        }

        public void Right()
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
    }
}
