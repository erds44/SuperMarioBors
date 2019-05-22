using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBros
{
    class MotionAnimatedSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 location;
        private int currentFrame;
        private int width;
        private int height;
        private int totalFrame = 6;
        private bool left;
        private float xMovement = 10;
        public MotionAnimatedSprite(Texture2D inputTexture, bool inputleft)
        {
            texture = inputTexture;
            left = inputleft;
            currentFrame = 0;
            width = texture.Width / totalFrame;
            height = texture.Height;
        }
        public void Update(ref Vector2 inputLocation)
        {
            currentFrame++;
            if (currentFrame == totalFrame)
            {
               currentFrame = 0;
            }
            UpdateLocation(ref inputLocation, left);
            location = inputLocation;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)(location.Y), width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        private void UpdateLocation(ref Vector2 inputLocation, bool left)
        {
            if (left)
            {
                if (inputLocation.X > 10)
                {
                    inputLocation.X -= xMovement;
                }
            }
            else
            {
                if (inputLocation.X < 750)
                {
                    inputLocation.X += xMovement;
                }
            }
        }
    }
}
