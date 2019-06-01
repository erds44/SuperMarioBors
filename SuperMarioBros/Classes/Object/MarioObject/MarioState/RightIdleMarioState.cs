using System;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioStates
{
    public class RightIdleMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;

        public RightIdleMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightIdle"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, "SmallMario"));
        }

        public void Down()
        {
            if (!type.Equals("SmallMario"))
            {
                mario.ChangeState(new RightCrouchingMarioState(mario, type));
            }
        }

        public void Fire()
        {
            //Do nothing yet.
        }

        public void Right()
        {
            mario.ChangeState(new RightMovingMarioState(mario, type));
        }

        public void Left()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, type));
        }

        public void ToBig()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "FireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "SmallMario"));
        }

        public void Up()
        {
            mario.ChangeState(new RightJumpingMarioState(mario, type));
        }

        public void Update()
        {
            // Do Nothing
        }
    }
}
