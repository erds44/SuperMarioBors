using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;
using System;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioMovementState
{
    public class RightMovingMarioState : IMarioMovementState
    {
        private readonly IMario mario;
        private string type;
        private readonly Physics marioPhysics;
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
            // Do Nothing
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
            marioPhysics.Right();
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
