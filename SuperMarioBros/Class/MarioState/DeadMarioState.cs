using System;

namespace SuperMarioBros.Class.MarioState
{
    public class DeadMarioState : IMarioState
    {
        private IMarioObject mario;
        private MarioGame game;
        private String type;
        public DeadMarioState(IMarioObject mario, MarioGame game, String type)
        {
            this.mario = mario;
            this.game = game;
            this.type = type;
            game.sprite = SpriteFactory.Instance.CreateSprite(type + "DeadSprite");
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
            mario.state = new RightIdleMarioState(mario, game, "smallMario");
        }

        public void ToBig()
        {
            mario.state = new RightIdleMarioState(mario, game, "bigMario");
        }

        public void ToFire()
        {
            mario.state = new RightIdleMarioState(mario, game, "fireMario");
        }

        public void Die()
        {
            //Do nothing.
        }

        public void Update()
        {
            //Do nothing.
        }
    }
}
