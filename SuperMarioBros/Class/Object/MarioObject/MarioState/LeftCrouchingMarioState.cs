using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class LeftCrouchingMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;
        public LeftCrouchingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.UpdateSprite(SpriteFactory.CreateSprite(type + "LeftCrouching"));      
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
            mario.ChangeState(new DeadMarioState(mario, type));
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
