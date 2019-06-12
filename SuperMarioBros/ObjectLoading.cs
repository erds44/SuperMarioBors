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
            for (int i = 1; i < objectNodes.objectList.Count; i++)
            {
                string objectType = objectNodes.objectList[i].ObjectType;
                Type t = Type.GetType(objectType);
                Point objectPosition = objectNodes.objectList[i].Position;
                var obj = Activator.CreateInstance(t, objectPosition);
                objects.Add((IObject)obj);
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
