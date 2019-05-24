using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class LeftMovingMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;
        public LeftMovingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftMoving"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, type));
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
