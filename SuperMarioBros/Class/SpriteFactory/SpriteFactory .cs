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
        private Texture2D smallMarioLeftIdleSprite;
        private Texture2D smallMarioRightIdleSprite;
        private Texture2D smallMarioLeftMovingSprite;
        private Texture2D smallMarioLeftJumpingSprite;
        private Texture2D smallMarioRightMovingSprite;
        private Texture2D smallMarioRightJumpingSprite;
        private Texture2D smallMarioDeadSprite;
        private Texture2D bigMarioLeftIdleSprite;
        private Texture2D bigMarioRightIdleSprite;
        private Texture2D bigMarioLeftMovingSprite;
        private Texture2D bigMarioLeftJumpingSprite;
        private Texture2D bigMarioLeftCrouchingSprite;
        private Texture2D bigMarioRightMovingSprite;
        private Texture2D bigMarioRightJumpingSprite;
        private Texture2D bigMarioRightCrouchingSprite;
        //private Dictionary<String,Texture2D> motionAnimatedTexture;
        //private Dictionary<String,Texture2D> motionlessFixedTexture;
        //private Dictionary<String, Texture2D> motionlessAnimatedTexture;

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
            smallMarioLeftIdleSprite = content.Load<Texture2D>("smallMarioLeftIdle");
            smallMarioRightIdleSprite = content.Load<Texture2D>("smallMarioRightIdle");
            smallMarioLeftMovingSprite = content.Load<Texture2D>("smallMarioLeftMoving");
            smallMarioLeftJumpingSprite = content.Load<Texture2D>("smallMarioLeftJumping");
            smallMarioRightMovingSprite = content.Load<Texture2D>("smallMarioRightMoving");
            smallMarioRightJumpingSprite = content.Load<Texture2D>("smallMarioRightJumping");
            smallMarioDeadSprite = content.Load<Texture2D>("smallMarioDead");
            bigMarioLeftIdleSprite = content.Load<Texture2D>("bigMarioLeftIdle");
            bigMarioRightIdleSprite = content.Load<Texture2D>("bigMarioRightIdle");
            bigMarioLeftMovingSprite = content.Load<Texture2D>("bigMarioLeftMoving");
            bigMarioLeftJumpingSprite = content.Load<Texture2D>("bigMarioLeftJumping");
            bigMarioLeftCrouchingSprite = content.Load<Texture2D>("bigMarioLeftCrouching");
            bigMarioRightMovingSprite = content.Load<Texture2D>("bigMarioRightMoving");
            bigMarioRightJumpingSprite = content.Load<Texture2D>("bigMarioRightJumping");
            bigMarioRightCrouchingSprite = content.Load<Texture2D>("bigMarioRightCrouching");
        }
        //private void AddToDictionary()
        //{
        //    motionlessFixedTexture.Add("smallMarioLeftIdleSprite", smallMarioLeftIdleSprite);
        //    motionlessFixedTexture.Add("smallMarioRightIdleSprite", smallMarioRightIdleSprite);
        //    motionAnimatedTexture.Add("smallMarioLeftMovingSprite", smallMarioLeftMovingSprite);
        //    motionlessAnimatedTexture.Add("smallMarioLeftJumpingSprite", smallMarioLeftJumpingSprite);
        //    motionlessFixedTexture.Add("smallMarioDeadSprite", smallMarioDeadSprite); // Change later
        //    motionAnimatedTexture.Add("smallMarioRightMovingSprite", smallMarioRightMovingSprite);
        //    motionlessAnimatedTexture.Add("smallMarioRightJumpingSprite", smallMarioRightJumpingSprite);
        //    motionlessFixedTexture.Add("bigMarioLeftIdleSprite", bigMarioLeftIdleSprite);
        //    motionlessFixedTexture.Add("bigMarioRightIdleSprite", bigMarioRightIdleSprite);
        //    motionAnimatedTexture.Add("bigMarioLeftMovingSprite", bigMarioLeftMovingSprite);
        //    motionlessAnimatedTexture.Add("bigMarioLeftJumpingSprite", bigMarioLeftJumpingSprite);
        //    motionlessFixedTexture.Add("bigMarioLeftCrouchingSprite", bigMarioLeftCrouchingSprite);
        //    motionAnimatedTexture.Add("bigMarioRightMovingSprite", bigMarioRightMovingSprite);
        //    motionlessAnimatedTexture.Add("bigMarioRightJumpingSprite", bigMarioRightJumpingSprite);
        //    motionlessFixedTexture.Add("bigMarioRightCrouchingSprite", bigMarioRightCrouchingSprite);
        //}
        public ISprite CreateSprite(string type)
        {
            ISprite sprite = null;
            switch (type)
            {
                case "smallMarioLeftIdleSprite":
                    return new MotionlessFixedSprite(smallMarioLeftIdleSprite);
                case "smallMarioRightIdleSprite":
                    return new MotionlessFixedSprite(smallMarioRightIdleSprite);
                case "smallMarioLeftMovingSprite":
                    return new MotionAnimatedSprite(smallMarioLeftMovingSprite, true);
                case "smallMarioLeftJumpingSprite":
                    return new MotionlessAnimatedSprite(smallMarioLeftJumpingSprite);
                case "smallMarioRightMovingSprite":
                    return new MotionAnimatedSprite(smallMarioRightMovingSprite, false);
                case "smallMarioRightJumpingSprite":
                    return new MotionlessAnimatedSprite(smallMarioRightJumpingSprite);
                case "smallMarioDeadSprite":
                    return new MotionlessFixedSprite(smallMarioDeadSprite); // TODO
                case "bigMarioLeftIdleSprite":
                    return new MotionlessFixedSprite(bigMarioLeftIdleSprite);
                case "bigMarioRightIdleSprite":
                    return new MotionlessFixedSprite(bigMarioRightIdleSprite);
                case "bigMarioLeftMovingSprite":
                    return new MotionAnimatedSprite(bigMarioLeftMovingSprite, true);
                case "bigMarioLeftJumpingSprite":
                    return new MotionlessAnimatedSprite(bigMarioLeftJumpingSprite);
                case "bigMarioLeftCrouchingSprite":
                    return new MotionlessFixedSprite(bigMarioLeftCrouchingSprite);
                case "bigMarioRightMovingSprite":
                    return new MotionAnimatedSprite(bigMarioRightMovingSprite, false);
                case "bigMarioRightJumpingSprite":
                    return new MotionlessAnimatedSprite(bigMarioRightJumpingSprite);
                case "bigMarioRightCrouchingSprite":
                    return new MotionlessFixedSprite(bigMarioRightCrouchingSprite);
            }
            return sprite;
        }
    }
}
