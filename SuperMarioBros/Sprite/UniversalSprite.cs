using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Sprites
{
    class UniversalSprite : ISprite
    {
        private readonly Texture2D texture;
        private int currentFrame;
        private readonly int width;
        private readonly int height;
        private readonly int totalFrame;
        private float dt = 0f;
        private float delayTime;
        private float layerDepth;
        public UniversalSprite(Texture2D texture, int frame,int spriteDelay)
        {
            delayTime = spriteDelay/(float)60;
            currentFrame = 0;
            layerDepth = 0.5f;
            this.texture = texture;
            totalFrame = frame;
            width = texture.Width / totalFrame;
            height = texture.Height;
        }
        public void SetLayer(float layer)
        {
            layerDepth = layer;
        }
        public void Update(GameTime gameTime)
        {
            dt += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (dt>delayTime)                              
            {               
                currentFrame++;
                if (currentFrame == totalFrame)
                    currentFrame = 0;
                dt = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location,SpriteEffects spriteEffects = SpriteEffects.None, float scale = 1f)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Vector2 Position = new Vector2((int)location.X, (int)location.Y - height * scale);

            spriteBatch.Draw(texture, Position, sourceRectangle, Color.White, 0f, Vector2.Zero, scale, spriteEffects, layerDepth);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteColor, SpriteEffects spriteEffects = SpriteEffects.None, float scale = 1f)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Vector2 Position = new Vector2((int)location.X, (int)location.Y - height * scale);

            spriteBatch.Draw(texture, Position, sourceRectangle, spriteColor, 0f, Vector2.Zero, scale, spriteEffects, layerDepth);
        }
    }
}
