using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Class.Object.GoombaObject;
using SuperMarioBros.Class.Object.MarioObject;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.Object.BlockObject;

namespace SuperMarioBros
{
    class InputAction : IReceiver
    {
        private MarioObject mario;
        private MarioGame game;
        private IBlockObject blockObject;
        public InputAction(MarioObject mario)
        {
            this.mario = mario;
        }
        public InputAction(MarioGame game)
        {
            this.game = game;
        }
        public InputAction(IBlockObject blockObject)
        {
            this.blockObject = blockObject;
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
        public void BigMario()
        {
            mario.ToBig();
        }
        public void SmallMario()
        {
            mario.ToSmall();

        }
        public void FireMario()
        {
            mario.ToFire();
        }
        public void DeadMario()
        {
            mario.Die();
        }
        public void Reset()
        {
            game.InitializeObjectsAndKeys();
        }
        public void Quit()
        {
            game.Exit();
        }

        public void QuestionBlockToUsedBlock()
        {
            blockObject.Used();
        }

        public void HiddenBlockToUsedBlock()
        {
            blockObject.Used();
        }

        public void BrickBlockDisappear()
        {
            blockObject.Disappear();
        }
    }
}
