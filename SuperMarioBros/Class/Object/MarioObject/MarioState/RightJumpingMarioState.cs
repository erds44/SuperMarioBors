using System;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class RightJumpingMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;
        public RightJumpingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightJumping"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, "SmallMario"));
        }

        public void Down()
        {
            //if (mario.jumpTimer== 0)
            //{
                mario.ChangeState(new RightIdleMarioState(mario, type));
            //}
        }

        public void Fire()
        {
            // Do Nothing yet.
        }

        public void Right()
        {
            // Do Nothing
        }

        public void Left()
        {
            // Do Nothing
        }

        public void ToBig()
        {
            mario.ChangeState(new RightJumpingMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightJumpingMarioState(mario, "FireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new RightJumpingMarioState(mario, "SmallMario"));
        }

        public void Up()
        {
            // Do Nothing
        }

        public void Update()
        {
            //mario.Jump(new Vector2(0, -10)); //jump speed
        }
    }
}
