using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Managers
{
    public static class SizeManager
    {
        private readonly static Dictionary<Type, Point> objectDictionary = new Dictionary<Type, Point>();
        private readonly static Dictionary<(Type, Type), Point> marioDictionary = new Dictionary<(Type, Type), Point>();

        public static void LoadItemSize(ContentManager content, string path)
        {
            SpriteList spriteList = content.Load<SpriteList>(path);
            for (int i = 0; i < spriteList.SpritesList.Count; i++)
            {
                string objectType = spriteList.SpritesList[i].ObjectType;
                Type t = Type.GetType(objectType);
                Point objectSize = spriteList.SpritesList[i].Size;
                if (t is null) continue;
                if (!objectDictionary.ContainsKey(t))
                    objectDictionary.Add(t, objectSize);

            }
            if (!objectDictionary.ContainsKey(typeof(HighPipe)))
                objectDictionary.Add(typeof(HighPipe), new Point(74, 170));
            if (!objectDictionary.ContainsKey(typeof(MiddlePipe)))
                objectDictionary.Add(typeof(MiddlePipe), new Point(74, 122));
            if (!objectDictionary.ContainsKey(typeof(UsedBlock)))
                objectDictionary.Add(typeof(UsedBlock), new Point(40, 40));
            if (!objectDictionary.ContainsKey(typeof(Goomba)))
                objectDictionary.Add(typeof(Goomba), new Point(31, 30));
            if (!objectDictionary.ContainsKey(typeof(Koopa)))
                objectDictionary.Add(typeof(Koopa), new Point(31, 43));
            // Used for debug
            //foreach (KeyValuePair<Type, Point> ele in objectDictionary)
            // {
            //     Console.WriteLine(ele);
            // }
        }

        public static void LoadMarioSize(ContentManager content, string path)
        {
            MarioList marioList = content.Load<MarioList>(path);
            for (int i = 0; i < marioList.MariosList.Count; i++)
            {
                string objectType = marioList.MariosList[i].ObjectType;
                string stateType = marioList.MariosList[i].StateType;
                Type tObject = Type.GetType(objectType);
                Type tState = Type.GetType(stateType);
                Point objectSize = marioList.MariosList[i].Size;
                if (!marioDictionary.ContainsKey((tObject, tState)))
                    marioDictionary.Add((tObject, tState), objectSize);

            }
            //Used for debug
            //foreach (KeyValuePair<(Type, Type), Point> ele in marioDictionary)
            //    {
            //        Console.WriteLine(ele);
            //    }
        }
        public static Point ObjectSize(Type type)
        {
            
            if (objectDictionary.TryGetValue(type, out Point size))
                return size;
            else
                Console.WriteLine("ERROR: The size of " + type + " is not loaded");
            return new Point();
        }
        public static Point MarioSize(Type typ1, Type typ2)
        {
            if (marioDictionary.TryGetValue((typ1, typ2), out Point size))
                return size;
            else
                Console.WriteLine("ERROR: The size of mario in " + typ1 + " and " + typ2 + " state is not loaded.");
            return new Point();
        }   
    }
}
