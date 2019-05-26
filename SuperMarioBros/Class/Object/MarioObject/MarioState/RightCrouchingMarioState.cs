using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class RightCrouchingMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;
        public RightCrouchingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightCrouching"));
        }

        public void Down()
        {
            // Do nothing
        }

        public void Right()
        {
            // Do nothing
        }

        public void Left()
        {
            // Do nothing
        }

        public void Up()
        {
            mario.ChangeState(new RightIdleMarioState(mario, type));
        }

        public void ToSmall()
        {
            // mario.ChangeState(new RightIdleMarioState(mario, "smallMario")); //smallMario cannot crouch.
        }

        public void ToBig()
        {
            mario.ChangeState(new RightCrouchingMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightCrouchingMarioState(mario, "FireMario"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, "SmallMario"));
        }

        public void Update()
        {
            // Do nothing.
        }

        public void Fire()
        {
            // Do nothing yet.
        }
    }
}
