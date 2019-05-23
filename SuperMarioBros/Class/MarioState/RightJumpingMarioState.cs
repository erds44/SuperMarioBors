using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public class RightJumpingMarioState : IMarioState
    {
        private IMarioObject mario;
        private MarioGame game;
        private String type;
        public RightJumpingMarioState(IMarioObject mario, MarioGame game, String type)
        {
            this.mario = mario;
            this.type = type;
            this.game = game;
            game.sprite = SpriteFactory.Instance.CreateSprite(type + "RightJumpingSprite");
        }

        public void Down()
        {
            mario.state = new RightIdleMarioState(mario, game, type);
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
            // Update Location
        }
    }
}
