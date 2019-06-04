using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioMovementState
{
    public class LeftCrouchingMarioState : AbstractMovementState,IMarioMovementState
    {
        public LeftCrouchingMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.marioPhysics = marioPhysics;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftCrouching"));
        }

        public void ChangeSprite(string type)
        {
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftCrouching"));
        }

        public void Down()
        {
            marioPhysics.Down();
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
            marioPhysics.Right();
        }


        public void Up()
        {
            mario.ChangeMovementState(new LeftIdleMarioState(mario, type, marioPhysics));
        }


        public void Update()
        {
            // Do Nothing
        }

    }
}
