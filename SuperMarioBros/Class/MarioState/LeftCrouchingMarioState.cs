using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class LeftCrouchingMarioState : IMarioState
    {
        private IMarioObject mario;
        private MarioGame game;
        private String type;
        public LeftCrouchingMarioState(IMarioObject mario, MarioGame game, String type)
        {
            this.mario = mario;
            this.game = game;
            this.type = type;
            game.sprite = SpriteFactory.Instance.CreateSprite(type + "LeftCrouchingSprite");      
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
            mario.state = new LeftIdleMarioState(mario, game, type);
        }

        public void Update()
        {
           // Do nothing
        }
    }
}
