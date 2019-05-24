using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class LeftJumpingMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;
        public LeftJumpingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftJumping"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, type));
        }

        public void Down()
        {
            mario.ChangeState(new LeftIdleMarioState(mario, type));
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
            mario.Jump(new Vector2(0,-10)); //jump speed
        }
    }
}
