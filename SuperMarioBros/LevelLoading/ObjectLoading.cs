using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.LevelLoading;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros
{
    public class ObjectLoading
    {
        private static ObjectList objectNodes;
        public static List<IObject> objectList { get; set; }
        public static Mario mario;
        public static void LevelLoading(ContentManager content, String path)
        {
            objectNodes = content.Load<ObjectList>(path);
            objectList = new List<IObject>();
            mario = new Mario(objectNodes.objectList[0].Position);
            for(int i = 1; i < objectNodes.objectList.Count; i++)
            {
                String objectType = objectNodes.objectList[i].ObjectType;
                Type t = Type.GetType(objectType);
                Vector2 objectPosition = objectNodes.objectList[i].Position;
                var obj = Activator.CreateInstance(t,objectPosition);
                objectList.Add((IObject)obj);
            }
        }
    }
}
