using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public class LeftMovingMarioState : IMarioState
    {
        private IMarioObject mario;
        private MarioGame game;
        private String type;
        public LeftMovingMarioState(IMarioObject mario, MarioGame game, String type)
        {
            this.mario = mario;
            this.type = type;
            this.game = game;
            game.sprite = SpriteFactory.Instance.CreateSprite(type + "LeftMovingSprite");
        }

        public void Down()
        {
            mario.state = new LeftCrouchingMarioState(mario, game, type);
        }

        public void Left()
        {
            // Do Nothing
        }

        public void Right()
        {
            mario.state = new LeftIdleMarioState(mario, game, type);
        }

        public void Up()
        {
            mario.state = new LeftJumpingMarioState(mario, game, type);
        }

        public void Update()
        {
            // Update location 
        }
    }
}
