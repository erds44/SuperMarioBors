using SuperMarioBros.Interfaces.States;
using System;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioStates
{
    public class DeadMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;

        public DeadMarioState(MarioObject mario, string type)
        {
            this.mario = mario;
            this.type = type;
            if (type.Equals("SmallMario"))
            {
                mario.ChangeSprite(SpriteFactory.CreateSprite(this.type + "Dead"));
            }
            else
            {
                mario.ChangeSprite(SpriteFactory.CreateSprite(this.type + "RightIdle"));
            }
        }
        public void Down()
        {
            //Do nothing.
        }

        public void Left()
        {
            //Do nothing.
        }

        public void Right()
        {
            //Do nothing.
        }

        public void Up()
        {
            //Do nothing.
        }

        public void ToSmall()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "SmallMario"));
        }

        public void ToBig()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "FireMario"));
        }

        public void Die()
        {
            //Do nothing.
        }

        public void Update()
        {
            //Do nothing.
        }

        public void Fire()
        {
            //Do nothing.
        }
    }
}
