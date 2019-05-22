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
        private MarioGame game;
        private enum MarioSprites {RightStill, LeftStill, RightMove, LeftMove, Dead};
        private MarioSprites currentSprite;
        private bool left;
        public InputAction(MarioGame mario)
        {
            left = false;
            game = mario;
            currentSprite = MarioSprites.RightStill;
            game.sprite = MarioSpriteFactory.Instance.CreateSprite("smallMarioStillRight");
        }

        public void MoveLeft() 
        {
            if (currentSprite != MarioSprites.LeftMove)
            {
                currentSprite = MarioSprites.LeftMove;
                left = true;
                game.sprite = MarioSpriteFactory.Instance.CreateSprite("smallMarioMoveLeft");
            }
        }
        public void MoveRight()
        {
            if (currentSprite != MarioSprites.RightMove)
            {
                currentSprite = MarioSprites.RightMove;
                left = false;
                game.sprite = MarioSpriteFactory.Instance.CreateSprite("smallMarioMoveRight");
            }
        }

        public void FaceLeftOrRight()
        {
            if (currentSprite != MarioSprites.RightStill || currentSprite != MarioSprites.LeftStill)
            {
                if (left)
                {
                    currentSprite = MarioSprites.LeftStill;
                    game.sprite = MarioSpriteFactory.Instance.CreateSprite("smallMarioStillLeft");
                }
                else
                {
                    currentSprite = MarioSprites.RightStill;
                    game.sprite = MarioSpriteFactory.Instance.CreateSprite("smallMarioStillRight");
                }
            }
        }
        public void Quit()
        {
            game.Exit();
        }

    }
}
