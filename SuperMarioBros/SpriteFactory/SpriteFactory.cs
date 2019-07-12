using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Sprites;
using SuperMarioBros.Loading;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.SpriteFactories
{
    public static class SpriteFactory
    {
        private static ContentManager content;
        private static Dictionary<string, SpritesNode> spritesInfo;
        private static ISprite sprite;
        private static SpritesNode spriteNode;

        public static void Initialize(ContentManager inputContent)
        {
            content = inputContent;
            SpritesLoader spritesLoading = new SpritesLoader();
            spritesInfo = spritesLoading.SpritesInfo();
        }

        public static ISprite CreateSprite(string type)
        {
            if (!(spritesInfo.TryGetValue(type, out spriteNode)))
               return null;
            sprite = new UniversalSprite(content.Load<Texture2D>(spriteNode.SpriteName), spriteNode.TotalFrame,(int)spriteNode.Delay);
            return sprite;
        }

        public static Point ObjectSize(string objectName)
        {
            if (spritesInfo.TryGetValue(objectName, out SpritesNode spriteNode))
                return new Point(spriteNode.Width, spriteNode.Height);
            return new Point();
        }
    }
}
