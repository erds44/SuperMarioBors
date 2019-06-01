using Microsoft.Xna.Framework;
using System;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioStates
{
    public class LeftMovingMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;
        public LeftMovingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftMoving"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, "SmallMario"));
        }

        public void Down()
        {
            if (!type.Equals("SmallMario"))
            {
                mario.ChangeState(new LeftCrouchingMarioState(mario, type));
            }
        }

        public void Fire()
        {
            // Do nothing yet.
        }

        public void Left()
        {
            // Do Nothing
        }

        public void Right()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, type));
        }

        public void ToBig()
        {
            mario.ChangeState(new LeftMovingMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new LeftMovingMarioState(mario, "FireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new LeftMovingMarioState(mario, "SmallMario"));
        }

        public void Up()
        {
            mario.ChangeState(new LeftJumpingMarioState(mario, type));
        }

        public void Update()
        {
            mario.Move(new Vector2(-10, 0));
        }
    }
}
