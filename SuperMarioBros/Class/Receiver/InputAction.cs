using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Class.Object.MarioObject;
using SuperMarioBros.Interface;

namespace SuperMarioBros
{
    class InputAction : IReceiver
    {
        private MarioGame game;
        public InputAction(MarioGame game)
        {
            this.game = game;
        }

        public void Left() 
        {
            game.mario.Left();
        }
        public void Right()
        {
            game.mario.Right();
        }

        public void Up()
        {
            game.mario.Up();
        }
        public void Down()
        {
            game.mario.Down();
        }
        public void BigMario()
        {
            game.mario.ToBig();
        }
        public void SmallMario()
        {
            game.mario.ToSmall();

        }
        public void FireMario()
        {
            game.mario.ToFire();
        }
        public void Quit()
        {
            game.Exit();
        }

    }
}
