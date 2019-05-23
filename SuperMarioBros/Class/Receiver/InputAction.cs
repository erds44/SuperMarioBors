using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros
{
    class InputAction : IReceiver
    {
        private IMarioObject mario;
        private MarioGame game;
        public InputAction(MarioGame game)
        {
            this.game = game;
            mario = new BigMario(game);
        }

        public void Left() 
        {
            mario.Left();
        }
        public void Right()
        {
            mario.Right();
        }

        public void Up()
        {
            mario.Up();
        }
        public void Down()
        {
            mario.Down();
        }
        public void Quit()
        {
            game.Exit();
        }

    }
}
