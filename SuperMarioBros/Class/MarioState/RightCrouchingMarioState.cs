using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class RightCrouchingMarioState : IMarioState
    {
        private IMarioObject mario;
        private MarioGame game;
        private String type;
        public RightCrouchingMarioState(IMarioObject mario, MarioGame game, String type)
        {
            this.mario = mario;
            this.type = type;
            this.game = game;
            game.sprite = SpriteFactory.Instance.CreateSprite(type + "RightCrouchingSprite");
        }

        public void Down()
        {
            // Do Nothing
        }

        public void Left()
        {
            // Do Nothing
        }

        public void Right()
        {
            // Do Nothing
        }

        public void Up()
        {
            mario.state = new RightIdleMarioState(mario, game, type);
        }

        public void Update()
        {
            // Do Nothing
        }
    }
}
