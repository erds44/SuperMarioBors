using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class LeftIdleMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;
        public LeftIdleMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.UpdateSprite(SpriteFactory.CreateSprite(type + "LeftIdleSprite"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, type));
        }

        public void Down()
        {
            mario.ChangeState(new LeftCrouchingMarioState(mario, type));
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
            mario.ChangeState(new LeftIdleMarioState(mario, "bigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, "fireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, "smallMario"));
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
