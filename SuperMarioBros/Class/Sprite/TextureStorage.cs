using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros
{
    public static class TextureStorage
    {
        private static Texture2D mario1LeftStill;
        private static Texture2D mario1LeftMove;
        private static Texture2D mario1RightStill;
        private static Texture2D mario1RightMove;
        private static Texture2D mario1Dead;
        public static void LoadAllTextures(ContentManager content)
        {
            mario1Dead = content.Load<Texture2D>("mario1Dead");
            mario1LeftStill = content.Load<Texture2D>("mario1LeftStill");
            mario1LeftMove = content.Load<Texture2D>("mario1LeftMove");
            mario1RightStill = content.Load<Texture2D>("mario1RightStill");
            mario1RightMove = content.Load<Texture2D>("mario1RightMove");
        }
        public static Texture2D GetMario1Dead()
        {
            return mario1Dead;
        }
        public static Texture2D GetMario1LeftStill()
        {
            return mario1LeftStill;
        }

        public static Texture2D GetMario1LeftMove()
        {
            return mario1LeftMove;
        }

        public static Texture2D GetMario1RightStill()
        {
            return mario1RightStill;
        }

        public static Texture2D GetMario1RightMove()
        {
            return mario1RightMove;
        }
    }
}
