using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Interface;
using SuperMarioBros.Class.Sprite;

namespace SuperMarioBros
{
    public static class SpriteFactory
    {
        private static ContentManager content;
        private static Dictionary<string, ISprite> spriteInfo;
        private static ISprite sprite;
        public static void Initialize(ContentManager inputContent)
        {
            content = inputContent;
            spriteInfo = new Dictionary<string, ISprite>();
            spriteInfo.Add("BigMarioLeftCrouching", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftCrouching"),1));
            spriteInfo.Add("BigMarioLeftIdle", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftIdle"), 1));
            spriteInfo.Add("BigMarioLeftJumping", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftJumping"), 1));
            spriteInfo.Add("BigMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftMoving"), 5));
            spriteInfo.Add("BigMarioRightCrouching", new UniversalSprite(content.Load<Texture2D>("BigMarioRightCrouching"), 1));
            spriteInfo.Add("BigMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("BigMarioRightIdle"), 1));
            spriteInfo.Add("BigMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("BigMarioRightJumping"), 1));
            spriteInfo.Add("BigMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("BigMarioRightMoving"), 5));
            spriteInfo.Add("BrickBlock", new UniversalSprite(content.Load<Texture2D>("BrickBlock"), 1));
            spriteInfo.Add("BrickDebris", new UniversalSprite(content.Load<Texture2D>("BrickDebris"), 1));
            spriteInfo.Add("Coin", new UniversalSprite(content.Load<Texture2D>("Coin"), 5));
            spriteInfo.Add("ConcreteBlock", new UniversalSprite(content.Load<Texture2D>("ConcreteBlock"), 1));
            spriteInfo.Add("EmptyBlock", new UniversalSprite(content.Load<Texture2D>("EmptyBlock"), 1));
            spriteInfo.Add("FireMarioLeftCrouching", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftCrouching"), 1));
            spriteInfo.Add("FireMarioLeftIdle", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftIdle"), 1));
            spriteInfo.Add("FireMarioLeftJumping", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftJumping"), 1));
            spriteInfo.Add("FireMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftMoving"), 6));
            spriteInfo.Add("FireMarioRightCrouching", new UniversalSprite(content.Load<Texture2D>("FireMarioRightCrouching"), 1));
            spriteInfo.Add("FireMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("FireMarioRightIdle"), 1));
            spriteInfo.Add("FireMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("FireMarioRightJumping"), 1));
            spriteInfo.Add("FireMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("FireMarioRightMoving"), 6));
            spriteInfo.Add("Flower", new UniversalSprite(content.Load<Texture2D>("Flower"), 5));
            spriteInfo.Add("Goomba", new UniversalSprite(content.Load<Texture2D>("Goomba"), 5));
            spriteInfo.Add("GoombaStomped", new UniversalSprite(content.Load<Texture2D>("GoombaStomped"), 1));
            spriteInfo.Add("GreenMushroom", new UniversalSprite(content.Load<Texture2D>("GreenMushroom"), 1));
            spriteInfo.Add("HiddenBlock", new UniversalSprite(content.Load<Texture2D>("HiddenBlock"), 1));
            spriteInfo.Add("KoopaMovingLeft", new UniversalSprite(content.Load<Texture2D>("KoopaMovingLeft"), 5));
            spriteInfo.Add("KoopaMovingRight", new UniversalSprite(content.Load<Texture2D>("KoopaMovingRight"), 5));
            spriteInfo.Add("KoopaStomped", new UniversalSprite(content.Load<Texture2D>("KoopaStomped"), 1));
            spriteInfo.Add("Pipe", new UniversalSprite(content.Load<Texture2D>("Pipe"), 1));
            spriteInfo.Add("QuestionBlock", new UniversalSprite(content.Load<Texture2D>("QuestionBlock"), 5));
            spriteInfo.Add("RedMushroom", new UniversalSprite(content.Load<Texture2D>("RedMushroom"), 1));
            spriteInfo.Add("RockBlock", new UniversalSprite(content.Load<Texture2D>("RockBlock"), 1));
            spriteInfo.Add("SmallMarioDead", new UniversalSprite(content.Load<Texture2D>("SmallMarioDead"), 1));
            spriteInfo.Add("SmallMarioLeftIdle", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftIdle"), 1));
            spriteInfo.Add("SmallMarioLeftJumping", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftJumping"), 1));
            spriteInfo.Add("SmallMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftMoving"), 5));
            spriteInfo.Add("SmallMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightIdle"), 1));
            spriteInfo.Add("SmallMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightJumping"), 1));
            spriteInfo.Add("SmallMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightMoving"), 5));
            spriteInfo.Add("Star", new UniversalSprite(content.Load<Texture2D>("Star"), 4));

        }

        public static ISprite CreateSprite(string type)
        {
            spriteInfo.TryGetValue(type, out sprite);
            return sprite;         
        }
    }
}
