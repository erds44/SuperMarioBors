using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public class LeftJumpingMarioState : IMarioState
    {
        private IMarioObject mario;
        private MarioGame game;
        private String type;
        public LeftJumpingMarioState(IMarioObject mario, MarioGame game, String type)
        {
            this.mario = mario;
            this.type = type;
            this.game = game;
            game.sprite = SpriteFactory.Instance.CreateSprite(type + "LeftJumpingSprite");
        }
        public void Down()
        {
            mario.state = new LeftIdleMarioState(mario, game, type);
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
           // Do Nothing
        }

        public void Update()
        {
           // Update location 
        }
    }
}
