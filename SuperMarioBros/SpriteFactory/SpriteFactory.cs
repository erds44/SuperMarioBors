﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Sprites;
using SuperMarioBros.Items;
using SuperMarioBros.Loading;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.SpriteFactories
{
    public static class SpriteFactory
    {
        private static ContentManager content;
        private static Dictionary<BrickPosition, ISprite> derbisSprite;
        private static Dictionary<string, SpritesNode> spritesInfo;
        private static ISprite sprite;
        private static SpritesNode spriteNode;
        public static void Initialize(ContentManager inputContent)
        {
            content = inputContent;
            SpritesLoading spritesLoading = new SpritesLoading();
            spritesInfo = spritesLoading.SpritesInfo();
            derbisSprite = new Dictionary<BrickPosition, ISprite>
            {
                { BrickPosition.leftTop, new UniversalSprite(content.Load<Texture2D>("LeftTopDerbis"), 1) },
                { BrickPosition.leftBottom, new UniversalSprite(content.Load<Texture2D>("LeftBottomDerbis"), 1) },
                { BrickPosition.rightTop, new UniversalSprite(content.Load<Texture2D>("RightTopDerbis"), 1) },
                { BrickPosition.rightBottom, new UniversalSprite(content.Load<Texture2D>("RightBottomDerbis"), 1) }
            };
        }

        public static ISprite CreateSprite(string type)
        {
            if (!(spritesInfo.TryGetValue(type, out spriteNode)))
                throw new System.ArgumentException("Cannot find: " + type + " in the dictionary");
            sprite = new UniversalSprite(content.Load<Texture2D>(spriteNode.SpriteName), spriteNode.TotalFrame);
            return sprite;
        }

        public static Point ObjectSize(string objectName)
        {
            if (spritesInfo.TryGetValue(objectName, out SpritesNode spriteNode))
                return new Point(spriteNode.Width, spriteNode.Height);
            return new Point();
        }

        public static ISprite CreateDerbisSprite(BrickPosition brickPosition)
        {
            derbisSprite.TryGetValue(brickPosition, out sprite);
            return sprite;
        }
    }
}
