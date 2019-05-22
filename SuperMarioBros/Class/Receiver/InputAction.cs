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
        private Texture2D texture;
        private enum MarioSprites {RightStill, LeftStill, RightMove, LeftMove, Dead};
        private MarioSprites currentSprite;
        private bool left;
        public InputAction(MarioGame mario)
        {
            left = false;
            game = mario;
            texture = TextureStorage.GetMario1RightStill();
            currentSprite = MarioSprites.RightStill;
            game.SetStillSprite(texture);
        }

        public void MoveLeft() 
        {
            if (currentSprite != MarioSprites.LeftMove)
            {
                texture = TextureStorage.GetMario1LeftMove();
                currentSprite = MarioSprites.LeftMove;
                left = true;
                game.SetMotionAnimatedSprite(texture, left);
            }
        }
        public void MoveRight()
        {
            if (currentSprite != MarioSprites.RightMove)
            {
                texture = TextureStorage.GetMario1RightMove();
                currentSprite = MarioSprites.RightMove;
                left = false;
                game.SetMotionAnimatedSprite(texture, left);
            }
        }

        public void FaceLeftOrRight()
        {
            if (currentSprite != MarioSprites.RightStill || currentSprite != MarioSprites.LeftStill)
            {
                if (left)
                {
                    texture = TextureStorage.GetMario1LeftStill();
                    currentSprite = MarioSprites.LeftStill;
                    game.SetStillSprite(texture);
                }
                else
                {
                    texture = TextureStorage.GetMario1RightStill();
                    currentSprite = MarioSprites.RightStill;
                    game.SetStillSprite(texture);
                }
            }
        }
        public void Quit()
        {
            game.Exit();
        }

    }
}
