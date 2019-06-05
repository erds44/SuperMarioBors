﻿using System.Collections.Generic;
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
                { "BigMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("BigMarioLeftMoving"), 5) },
                { "BigMarioRightCrouching", new UniversalSprite(content.Load<Texture2D>("BigMarioRightCrouching"), 1) },
                { "BigMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("BigMarioRightIdle"), 1) },
                { "BigMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("BigMarioRightJumping"), 1) },
                { "BigMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("BigMarioRightMoving"), 5) },
                { "BrickBlock", new UniversalSprite(content.Load<Texture2D>("BrickBlock"), 1) },
                { "BrickDebris", new UniversalSprite(content.Load<Texture2D>("BrickDebris"), 1) },
                { "Coin", new UniversalSprite(content.Load<Texture2D>("Coin"), 5) },
                { "ConcreteBlock", new UniversalSprite(content.Load<Texture2D>("ConcreteBlock"), 1) },
                { "EmptyBlock", new UniversalSprite(content.Load<Texture2D>("EmptyBlock"), 1) },
                { "FireMarioLeftCrouching", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftCrouching"), 1) },
                { "FireMarioLeftIdle", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftIdle"), 1) },
                { "FireMarioLeftJumping", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftJumping"), 1) },
                { "FireMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("FireMarioLeftMoving"), 6) },
                { "FireMarioRightCrouching", new UniversalSprite(content.Load<Texture2D>("FireMarioRightCrouching"), 1) },
                { "FireMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("FireMarioRightIdle"), 1) },
                { "FireMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("FireMarioRightJumping"), 1) },
                { "FireMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("FireMarioRightMoving"), 6) },
                { "Flower", new UniversalSprite(content.Load<Texture2D>("Flower"), 5) },
                { "Goomba", new UniversalSprite(content.Load<Texture2D>("Goomba"), 5) },
                { "GoombaStomped", new UniversalSprite(content.Load<Texture2D>("GoombaStomped"), 1) },
                { "GreenMushroom", new UniversalSprite(content.Load<Texture2D>("GreenMushroom"), 1) },
                { "HiddenBlock", new UniversalSprite(content.Load<Texture2D>("HiddenBlock"), 1) },
                { "KoopaMovingLeft", new UniversalSprite(content.Load<Texture2D>("KoopaMovingLeft"), 5) },
                { "KoopaMovingRight", new UniversalSprite(content.Load<Texture2D>("KoopaMovingRight"), 5) },
                { "KoopaStomped", new UniversalSprite(content.Load<Texture2D>("KoopaStomped"), 1) },
                { "Pipe", new UniversalSprite(content.Load<Texture2D>("Pipe"), 1) },
                { "QuestionBlock", new UniversalSprite(content.Load<Texture2D>("QuestionBlock"), 5) },
                { "RedMushroom", new UniversalSprite(content.Load<Texture2D>("RedMushroom"), 1) },
                { "RockBlock", new UniversalSprite(content.Load<Texture2D>("RockBlock"), 1) },
                { "SmallMarioDead", new UniversalSprite(content.Load<Texture2D>("SmallMarioDead"), 1) },
                { "SmallMarioLeftIdle", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftIdle"), 1) },
                { "SmallMarioLeftJumping", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftJumping"), 1) },
                { "SmallMarioLeftMoving", new UniversalSprite(content.Load<Texture2D>("SmallMarioLeftMoving"), 5) },
                { "SmallMarioRightIdle", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightIdle"), 1) },
                { "SmallMarioRightJumping", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightJumping"), 1) },
                { "SmallMarioRightMoving", new UniversalSprite(content.Load<Texture2D>("SmallMarioRightMoving"), 5) },
                { "Star", new UniversalSprite(content.Load<Texture2D>("Star"), 4) }
            };
            
        }

        public static ISprite CreateSprite(string type)
        {
            spriteInfo.TryGetValue(type, out sprite);
            return sprite;
        }
    }
}