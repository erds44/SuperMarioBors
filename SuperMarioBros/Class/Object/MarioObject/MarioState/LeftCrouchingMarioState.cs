using System;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class LeftCrouchingMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;
        public LeftCrouchingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftCrouching"));      
        }

        public void Down()
        {
            // Do nothing
        }

        public void Left()
        {
           // Do nothing
        }

        public void Right()
        {
           // Do nothing
        }

        public void Up()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, type));
        }

        public void ToSmall() {
            // Try Do Nothing
            // mario.ChangeState(new LeftIdleMarioState(mario, "SmallMario")); //smallMario cannot crouch.
        }

        public void ToBig() {
           mario.ChangeState(new LeftCrouchingMarioState(mario, "BigMario"));
        }

        public void ToFire() {
            mario.ChangeState(new LeftCrouchingMarioState(mario, "FireMario"));
        }

        public void Die() {
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
