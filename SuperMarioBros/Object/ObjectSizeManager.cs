using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Objects
{
    public static class ObjectSizeManager
    {
        /* all the size infomation will not get from texture width and height any more 
           we have to predefine a size infomation
        */
        private static Dictionary<Type, Vector2> objectSize;
        private static Dictionary<(Type, Type), Vector2> marioSize;
        public static Vector2 Size(Type type)
        {
            return new Vector2(0, 0);
        }
        public static Vector2 Size(Type type1, Type type2)
        {
            return new Vector2(0, 0);
        }
        private static void Initialize()
        {
            objectSize = new Dictionary<Type, Vector2>();
           // objectSize.Add(Mario, new Vector2(200, 100));
        }
    }
}
