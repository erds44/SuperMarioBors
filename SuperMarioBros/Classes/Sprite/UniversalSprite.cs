using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Sprite
{
    class UniversalSprite : ISprite
    {
        private Texture2D texture;
        private int currentFrame;
        private int width;
        private int height;
        private int totalFrame;
        public UniversalSprite(Texture2D texture, int frame)
        {
            this.texture = texture;
            totalFrame = frame;
            width = texture.Width / totalFrame;
            height = texture.Height;
            currentFrame = 0;
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrame)
            {
               currentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y - height, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Vector2 Size()
        {
            return new Vector2((float)width, (float)height);
        }
    }
}
