using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SuperMarioBros
{
    class SpriteFactory
    {
        private Texture2D smallMarioStillLeft;
        private Texture2D smallMarioStillRight;
        private Texture2D smallMarioMoveLeft;
        private Texture2D smallMarioMoveRight;
        private Texture2D smallMarioDead;

        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private SpriteFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            smallMarioDead = content.Load<Texture2D>("smallMarioDead");
            smallMarioStillLeft = content.Load<Texture2D>("smallMarioStillLeft");
            smallMarioMoveLeft = content.Load<Texture2D>("smallMarioMoveLeft");
            smallMarioStillRight = content.Load<Texture2D>("smallMarioStillRight");
            smallMarioMoveRight = content.Load<Texture2D>("smallMarioMoveRight");
        }
        public ISprite CreateSprite(string type)
        {
            ISprite sprite = null;
            if (type.Equals("smallMarioStillRight"))
            {
                sprite = new MotionlessFixedSprite(smallMarioStillRight);
            }else if(type.Equals("smallMarioStillLeft"))
            {
                sprite = new MotionlessFixedSprite(smallMarioStillLeft);
            }
            else if (type.Equals("smallMarioMoveRight"))
            {
                sprite = new MotionAnimatedSprite(smallMarioMoveRight,false);
            }
            else if (type.Equals("smallMarioMoveLeft"))
            {
                sprite = new MotionAnimatedSprite(smallMarioMoveLeft,true);
            }
            else if (type.Equals("samllMarioDead"))
            {
                sprite = new MotionlessFixedSprite(smallMarioDead);
            }
            return sprite;

        }
    }
}
