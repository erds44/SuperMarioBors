using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioMovementState
{
    public class RightCrouchingMarioState : AbstractMovementState, IMarioMovementState
    { 
        public RightCrouchingMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.marioPhysics = marioPhysics;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightCrouching"));
        }

        public void Down()
        {
            marioPhysics.Down();
        }

        public void Right()
        {
            marioPhysics.Right();
        }

        public void Left()
        {
            marioPhysics.Left();
        }

        public void Up()
        {
            mario.ChangeMovementState(new RightIdleMarioState(mario,type, marioPhysics));
        }
     
        public void Update()
        {
            // Do nothing.
        }

        public void ChangeSprite(string type)
        {
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightCrouching"));
        }

        public void Idle()
        {
            mario.ChangeMovementState(new RightIdleMarioState(mario, type, marioPhysics));
        }
    }
}
