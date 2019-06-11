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
        public static void LevelLoading(ContentManager content, string path)
        {
            objectNodes = content.Load<ObjectList>(path);
            ObjectsManager.Instance.StaticObjects = new List<IObject>();
            ObjectsManager.Instance.Mario = new List<IMario> { new Mario(objectNodes.objectList[0].Position) };
            for(int i = 1; i < objectNodes.objectList.Count; i++)
            {
                string objectType = objectNodes.objectList[i].ObjectType;
                Type t = Type.GetType(objectType);
                Point objectPosition = objectNodes.objectList[i].Position;
                var obj = Activator.CreateInstance(t,objectPosition);
                ObjectsManager.Instance.StaticObjects.Add((IObject)obj);
            }
        }
    }
}
