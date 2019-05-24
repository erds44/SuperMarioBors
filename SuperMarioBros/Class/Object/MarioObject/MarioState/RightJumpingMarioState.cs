using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject.MarioState
{
    public class RightJumpingMarioState : IMarioState
    {
        private MarioObject mario;
        private String type;
        public RightJumpingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            mario.UpdateSprite(SpriteFactory.CreateSprite(type + "RightJumpingSprite"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, type));
        }

        public void Down()
        {
            mario.ChangeState(new RightIdleMarioState(mario, type));
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
            mario.ChangeState(new RightJumpingMarioState(mario, "bigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightJumpingMarioState(mario, "fireMario"));
        }

        public void ToSmall()
        {
            mario.ChangeState(new RightJumpingMarioState(mario, "smallMario"));
        }

        public void Up()
        {
            // Do Nothing
        }

        public void Update()
        {
            mario.Move(new Vector2(0, -1)); //jump speed
        }
    }
}
