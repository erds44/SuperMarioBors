using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public class RightIdleMarioState : IMarioState
    {
        private IMarioObject mario;
        private MarioGame game;
        private String type;
        public RightIdleMarioState(IMarioObject mario, MarioGame game, String type)
        {
            this.mario = mario;
            this.type = type;
            this.game = game;
            game.sprite = SpriteFactory.Instance.CreateSprite(type + "RightIdleSprite");
        }

        public void Down()
        {
            mario.state = new RightCrouchingMarioState(mario, game, type);
        }

        public void Left()
        {
            mario.state = new LeftIdleMarioState(mario, game, type);
        }

        public void Right()
        {
            mario.state = new RightMovingMarioState(mario, game, type);
        }

        public void Up()
        {
            mario.state = new RightJumpingMarioState(mario, game, type);
        }

        public void Update()
        {
            // Do Nothing
        }
    }
}
