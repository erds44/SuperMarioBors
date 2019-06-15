using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.LevelLoading;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMarioBros
{
    public static class ObjectLoading
    {
        private static ObjectList objectNodes;
        private static Collection<IMario> mario;
        private static Collection<IObject> objects;
        public static void LevelLoading(ContentManager content, string path)
        {
            objectNodes = content.Load<ObjectList>(path);
            objects = new Collection<IObject>();
            mario = new Collection<IMario> { new Mario(objectNodes.objectList[0].Position) };
            //This part is only for temprorary test
            Point firstBlock = objectNodes.objectList[1].Position;
            Type typeofBlock = Type.GetType(objectNodes.objectList[1].ObjectType);
            Point currentBlock = firstBlock;
            currentBlock.Y = 440;
            while (currentBlock.Y < 600)
            {
                var obj = Activator.CreateInstance(typeofBlock, currentBlock);
                objects.Add((IObject)obj);
                currentBlock.X += 40;
                if (currentBlock.X >= 800)
                {
                    currentBlock.X = 0;
                    currentBlock.Y += 40;

                }
            }
            for (int i = 2; i < objectNodes.objectList.Count; i++)
            {
                string objectType = objectNodes.objectList[i].ObjectType;
                Type t = Type.GetType(objectType);
                Point objectPosition = objectNodes.objectList[i].Position;
                var obj = Activator.CreateInstance(t, objectPosition);
                objects.Add((IObject)obj);
            }

            foreach(IObject obj in objects)
            {
                Console.WriteLine(obj.GetType());
            }
        }
        public static Collection<IMario> LoadMario()
        {
            return mario;
        }
        public static Collection<IObject> LoadObject()
        { 
            return objects;
        }
    }
}
