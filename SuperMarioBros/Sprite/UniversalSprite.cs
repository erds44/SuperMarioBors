using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
        private int delay;
        private Collection<Color> SpriteColor;
        private int count;
        private float layerDepth;
        public UniversalSprite(Texture2D texture, int frame)
        {
            this.texture = texture;
            totalFrame = frame;
            width = texture.Width / totalFrame;
            height = texture.Height;
            currentFrame = 0;
            delay = 0;
            SpriteColor = new Collection<Color> { Color.White };
            count = 0;
            layerDepth = 0.5f;
        }
        public void SetColor(Collection<Color> colors)
        {
            SpriteColor = colors;
        }
        public void Update()
        {
            /* the delay here is to slow doown the animation
             * There might be a better solution to do this
             */
            delay++;
            if (delay % 10 == 0)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                delay = 0;
                count++;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int row = (int)((float)currentFrame / (float)totalFrame);
            int column = currentFrame % totalFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y - height, width, height);

            /* This condition is used for alternating colors for star mario */
            if (count % SpriteColor.Count == 0 || count > SpriteColor.Count)
            {
                count = 0;
            }
            Color spriteColor = SpriteColor[count];
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, spriteColor, 0,new Vector2(0,0),SpriteEffects.None, layerDepth);   
        }
        public void SetLayer(float layer)
        {
            this.layerDepth = layer;
        }
    }
}
