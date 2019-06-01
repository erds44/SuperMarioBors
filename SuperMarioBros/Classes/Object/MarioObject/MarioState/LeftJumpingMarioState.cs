using System;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioStates
{
    public class LeftJumpingMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;
        public LeftJumpingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftJumping"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, "SmallMario"));
        }

        public void Down()
        {
            //if (mario.jumpTimer == 0)
            //{
                mario.ChangeState(new LeftIdleMarioState(mario, type));
            //}
        }

        public void Fire()
        {
            // Do Nothing yet.
        }

        public void Left()
        {
            // Do Nothing
        }

        public void Right()
        {
           // Do Nothing
        }

        public void ToBig()
        {
            mario.ChangeState(new LeftJumpingMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new LeftJumpingMarioState(mario, "FireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new LeftJumpingMarioState(mario, "SmallMario"));
        }

        public void Up()
        {
           // Do Nothing
        }

        public void Update()
        {
            //mario.Jump(new Vector2(0,-10)); //jump speed
        }
    }
}
