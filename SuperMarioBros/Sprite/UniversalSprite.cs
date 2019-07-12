using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Utility;
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
        private float dt = Timers.InitialTime;
        private float delayTime;
        private float layerDepth;
        public UniversalSprite(Texture2D texture, int frame,int spriteDelay)
        {
            delayTime = spriteDelay/Timers.RefreshFrequency;
            currentFrame =SpriteConsts.InitialFrame;
            layerDepth = Layers.DefaultLayer;
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
                dt = Timers.InitialTime;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location,SpriteEffects spriteEffects = SpriteEffects.None, float scale = SpriteConsts.DefaultScale)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Vector2 Position = new Vector2((int)location.X, (int)location.Y - height * scale);

            spriteBatch.Draw(texture, Position, sourceRectangle, Color.White, SpriteConsts.DefaultRotation, Vector2.Zero, scale, spriteEffects, layerDepth);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteColor, SpriteEffects spriteEffects = SpriteEffects.None, float scale = SpriteConsts.DefaultScale)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Vector2 Position = new Vector2((int)location.X, (int)location.Y - height * scale);

            spriteBatch.Draw(texture, Position, sourceRectangle, spriteColor, SpriteConsts.DefaultRotation, Vector2.Zero, scale, spriteEffects, layerDepth);
        }
    }
}
