using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class RightMovingMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;
        public RightMovingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.UpdateSprite(SpriteFactory.CreateSprite(type + "RightMoving"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, type));
        }

        public void Down()
        {
            if (type.Equals("BigMario") || type.Equals("FireMario"))
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
