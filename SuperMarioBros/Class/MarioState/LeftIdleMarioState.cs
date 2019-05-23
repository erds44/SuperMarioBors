using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public class LeftIdleMarioState : IMarioState
    {
        private IMarioObject mario;
        private MarioGame game;
        private String type;
        public LeftIdleMarioState(IMarioObject mario, MarioGame game, String type)
        {
            this.mario = mario;
            this.type = type;
            this.game = game;
            game.sprite = SpriteFactory.Instance.CreateSprite(type + "LeftIdleSprite");
        }

        public void Down()
        {
            mario.state = new LeftCrouchingMarioState(mario, game, type);
        }

        public void Left()
        {
            mario.state = new LeftMovingMarioState(mario, game, type);
        }

        public void Right()
        {
            mario.state = new RightIdleMarioState(mario, game, type);
        }

        public void Up()
        {
            mario.state = new LeftJumpingMarioState(mario, game, type);
        }

        public void Update()
        {
            // Do Nothing
        }
    }
}
