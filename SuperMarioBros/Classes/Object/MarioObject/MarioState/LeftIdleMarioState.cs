using System;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioStates
{
    public class LeftIdleMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;
        public LeftIdleMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftIdle"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, "SmallMario"));
        }

        public void Down()
        {
            if(!type.Equals("SmallMario"))
            {
                mario.ChangeState(new LeftCrouchingMarioState(mario, type));
            }
        }

        public void Fire()
        {
            //Do nothing yet.
        }

        public void Left()
        {
            mario.ChangeState(new LeftMovingMarioState(mario, type));
        }

        public void Right()
        {
            mario.ChangeState(new RightIdleMarioState(mario, type));
        }

        public void ToBig()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, "FireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, "SmallMario"));
        }

        public void Up()
        {
            mario.ChangeState(new LeftJumpingMarioState(mario, type));
        }

        public void Update()
        {
            // Do Nothing
        }
    }
}
