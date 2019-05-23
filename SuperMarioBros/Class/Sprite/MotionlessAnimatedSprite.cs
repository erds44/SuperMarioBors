using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros
{
    class MotionlessAnimatedSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 location;
        private int currentFrame;
        private int width;
        private int height;
        private int totalFrame = 5;
        private bool left;
        private float yMovement = 10;
        public MotionlessAnimatedSprite(Texture2D inputTexture)
        {
            texture = inputTexture;
            // TODO
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(ref Vector2 location)
        {
            throw new NotImplementedException();
            // this is a Jumper Feature, to do
        }
    }
}
