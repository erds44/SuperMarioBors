using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Sprites
{
    class UniversalSprite : ISprite
    {
        private readonly Texture2D texture;
        private int currentFrame;
        private readonly int width;
        private readonly int height;
        private readonly int totalFrame;
        private int delay;
        public UniversalSprite(Texture2D texture, int frame)
        {
            this.texture = texture;
            totalFrame = frame;
            width = texture.Width / totalFrame;
            height = texture.Height;
            currentFrame = 0;
            delay = 0;
        }
        public void Update()
        {
            delay++;
            if (delay % 5 == 0)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                delay = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X, location.Y - height, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public int Width()
        {
            return width;
        }

        public int Height()
        {
            return height;
        }
    }
}
