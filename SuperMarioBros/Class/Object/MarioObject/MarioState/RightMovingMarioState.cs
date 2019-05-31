using Microsoft.Xna.Framework;
using System;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class RightMovingMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;
        public RightMovingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightMoving"));
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
            // Do nothing yet.
        }

        public void Right()
        {
            // Do Nothing
        }

        public void Left()
        {
            mario.ChangeState(new RightIdleMarioState(mario, type));
        }

        public void ToBig()
        {
            mario.ChangeState(new RightMovingMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightMovingMarioState(mario, "FireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new RightMovingMarioState(mario, "SmallMario"));
        }

        public void Up()
        {
            mario.ChangeState(new RightJumpingMarioState(mario, type));
        }

        public void Update()
        {
            mario.Move(new Vector2(10, 0));
        }
    }
}
