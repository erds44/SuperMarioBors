﻿using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftMovingMarioState : AbstractMovementState, IMarioMovementState
    {
        public LeftMovingMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.marioPhysics = marioPhysics;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftMoving"));
        }

        public void ChangeSprite(string type)
        {
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftMoving"));
        }

        public void Down()
        {
            if (!type.Equals("SmallMario"))
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
            mario.ChangeMovementState(new LeftIdleMarioState(mario, type, marioPhysics));
        }

        public void Left()
        {
            marioPhysics.Left();
        }

        public void Right()
        {
            mario.ChangeMovementState(new LeftIdleMarioState(mario, type, marioPhysics));
        }

        public void Up()
        {
            mario.ChangeMovementState(new LeftJumpingMarioState(mario, type, marioPhysics));
        }

        public void Update()
        {
            //marioPhysics.Left();
        }
    }
}