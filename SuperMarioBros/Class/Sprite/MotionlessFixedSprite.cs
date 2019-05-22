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
    class MotionlessFixedSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 location;
        private int width;
        private int height;

        public MotionlessFixedSprite(Texture2D inputTexture)
        {
            texture = inputTexture;
            width = texture.Width;
            height = texture.Height;
        }
        public void Update(ref Vector2 inputLocation)
        {
            location = inputLocation;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)(location.Y), width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
