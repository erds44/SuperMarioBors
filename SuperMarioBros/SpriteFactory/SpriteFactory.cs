using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.SpriteFactories
{
    public static class SpriteFactory
    {
        private static ContentManager content;
        private static Dictionary<string, ISprite> spriteInfo;
        private static ISprite sprite;
        public static void Initialize(ContentManager inputContent)
        {
            content = inputContent;
            spriteInfo = new Dictionary<string, ISprite>
            {
                { "BigMarioLeftCrouching", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftCrouching"), 1) },
                { "BigMarioLeftIdle", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftIdle"), 1) },
                { "BigMarioLeftJumping", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftJumping"), 1) },
                { "BigMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftMoving"), 4) },
                { "BigMarioRightCrouching", new UniversalSprite(content.Load<Texture2D>("BigMarioRightCrouching"), 1) },
                { "BigMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("BigMarioRightIdle"), 1) },
                { "BigMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("BigMarioRightJumping"), 1) },
                { "BigMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("BigMarioRightMoving"), 4) },
                { "BrickBlockState", new UniversalSprite(content.Load<Texture2D>("BrickBlock"), 1) },
                { "BrickDebris", new UniversalSprite(content.Load<Texture2D>("BrickDebris"), 1) },
                { "Coin", new UniversalSprite(content.Load<Texture2D>("Coin"), 5) },
                { "ConcreteBlockState", new UniversalSprite(content.Load<Texture2D>("ConcreteBlock"), 1) },
                { "UsedBlockState", new UniversalSprite(content.Load<Texture2D>("UsedBlock"), 1) },
                { "FireMarioLeftCrouching", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftCrouching"), 1) },
                { "FireMarioLeftIdle", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftIdle"), 1) },
                { "FireMarioLeftJumping", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftJumping"), 1) },
                { "FireMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftMoving"), 5) },
                { "FireMarioRightCrouching", new UniversalSprite(content.Load<Texture2D>("FireMarioRightCrouching"), 1) },
                { "FireMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("FireMarioRightIdle"), 1) },
                { "FireMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("FireMarioRightJumping"), 1) },
                { "FireMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("FireMarioRightMoving"), 5) },
                { "Flower", new UniversalSprite(content.Load<Texture2D>("Flower"), 5) },
                { "GoombaLeftMoving", new UniversalSprite(content.Load<Texture2D>("Goomba"), 5) },
                { "GoombaRightMoving", new UniversalSprite(content.Load<Texture2D>("Goomba"), 5) },
                { "StompedGoomba", new UniversalSprite(content.Load<Texture2D>("GoombaStomped"), 1) },
                { "GreenMushroom", new UniversalSprite(content.Load<Texture2D>("GreenMushroom"), 1) },
                { "HiddenBlockState", new UniversalSprite(content.Load<Texture2D>("HiddenBlock"), 1) },
                { "DisappearBlockState", new UniversalSprite(content.Load<Texture2D>("HiddenBlock"), 1) },
                { "KoopaLeftMoving", new UniversalSprite(content.Load<Texture2D>("KoopaMovingLeft"), 5) },
                { "KoopaRightMoving", new UniversalSprite(content.Load<Texture2D>("KoopaMovingRight"), 5) },
                { "StompedKoopa", new UniversalSprite(content.Load<Texture2D>("KoopaStomped"), 1) },
                { "Pipe", new UniversalSprite(content.Load<Texture2D>("Pipe"), 1) },
                { "QuestionBlockState", new UniversalSprite(content.Load<Texture2D>("QuestionBlock"), 5) },
                { "RedMushroom", new UniversalSprite(content.Load<Texture2D>("RedMushroom"), 1) },
                { "RockBlockState", new UniversalSprite(content.Load<Texture2D>("RockBlock"), 1) },
                { "DeadMario", new UniversalSprite(content.Load<Texture2D>("DeadMario"), 1) },
                { "SmallMarioLeftIdle", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftIdle"), 1) },
                { "SmallMarioLeftJumping", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftJumping"), 1) },
                { "SmallMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftMoving"), 4) },
                { "SmallMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightIdle"), 1) },
                { "SmallMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightJumping"), 1) },
                { "SmallMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightMoving"), 4) },
                { "SmallMarioLeftBreaking", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftBreaking"), 1) },
                { "SmallMarioRightBreaking", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightBreaking"), 1) },
                { "BigMarioRightBreaking", new UniversalSprite(content.Load<Texture2D>("BigMarioRightBreaking"), 1) },
                { "BigMarioLeftBreaking", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftBreaking"), 1) },
                { "FireMarioRightBreaking", new UniversalSprite(content.Load<Texture2D>("FireMarioRightBreaking"), 1) },
                { "FireMarioLeftBreaking", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftBreaking"), 1) },
                { "Star", new UniversalSprite(content.Load<Texture2D>("Star"), 4) },
                { "BigHill", new UniversalSprite(content.Load<Texture2D>("BigHill"), 1) },
                { "BigBush", new UniversalSprite(content.Load<Texture2D>("BigBush"), 1) },
                { "SmallBush", new UniversalSprite(content.Load<Texture2D>("SmallBush"), 1) },
                { "MiddleCloud", new UniversalSprite(content.Load<Texture2D>("MiddleCloud"), 1) },
                { "SmallHill", new UniversalSprite(content.Load<Texture2D>("SmallHill"), 1) },
                { "BigCloud", new UniversalSprite(content.Load<Texture2D>("BigCloud"), 1) },
                { "SmallCloud", new UniversalSprite(content.Load<Texture2D>("SmallCloud"), 1) }
            };
            
        }

        public static ISprite CreateSprite(string type)
        { 
            if(!(spriteInfo.TryGetValue(type, out sprite)))
            {
                throw new System.ArgumentException("Cannot find: " + type + " in the dictionary");
            }
            return sprite;
        }
    }
}
