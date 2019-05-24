using SuperMarioBros.Interface.State;
using System;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class DeadMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;

        public DeadMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.UpdateSprite(SpriteFactory.CreateSprite(this.type + "DeadSprite"));
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
            mario.ChangeState(new RightIdleMarioState(mario, "smallMario"));
        }

        public void ToBig()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "bigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightIdleMarioState(mario, "fireMario"));
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
