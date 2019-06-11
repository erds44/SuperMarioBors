using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Goombas;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Objects
{
    public static class ObjectSizeManager
    {
        /* all the size infomation will not get from texture width and height any more 
           we have to predefine a size infomation
           This class is not in used currently, but used in refactor part
        */
        private static Dictionary<Type, Point> objectDictionary = new Dictionary<Type, Point>();
        private static Dictionary<(Type, Type), Point> marioDictionary = new Dictionary<(Type, Type), Point>();

        public static void LoadItemSize(ContentManager content, String path)
        {
            SpriteList spriteList = content.Load<SpriteList>(path);
            for (int i = 1; i < spriteList.SpritesList.Count; i++)
            {
                String objectType = spriteList.SpritesList[i].ObjectType;
                Type t = Type.GetType(objectType);
                Point objectSize = spriteList.SpritesList[i].Size;
                if (!objectDictionary.ContainsKey(t))
                {
                    objectDictionary.Add(t, objectSize);
                }
            }

        }

        public static void LoadMarioSize(ContentManager content, String path)
        {
            MarioList marioList = content.Load<MarioList>(path);
            for (int i = 1; i < marioList.MariosList.Count; i++)
            {
                String objectType = marioList.MariosList[i].ObjectType;
                String stateType = marioList.MariosList[i].StateType;
                Type tObject = Type.GetType(objectType);
                Type tState = Type.GetType(stateType);
                Point objectSize = marioList.MariosList[i].Size;
                if (!marioDictionary.ContainsKey((tObject, tState)))
                {
                    marioDictionary.Add((tObject, tState), objectSize);
                }
            }
        }
    }
}
