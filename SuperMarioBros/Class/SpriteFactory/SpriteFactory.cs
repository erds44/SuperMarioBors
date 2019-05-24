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
        public static void Initialize(ContentManager inputContent)
        {
            content = inputContent;
        }

        public static ISprite CreateSprite(string type)
        {
            return new UniversalSprite(content.Load<Texture2D>(type));
        }
    }
}
