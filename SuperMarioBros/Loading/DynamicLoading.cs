﻿using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioBros.Loading
{
    public class DynamicLoader
    {
        //This is just a buffer -- Load objects in a "effective" range. This could reduce memory use.
        private List<(float, IStatic)> staticObjects = new List<(float, IStatic)>();
        private List<(float, IDynamic)> dynamicObjects = new List<(float, IDynamic)>();
        private List<(float, IObject)> nonCollidableObjects = new List<(float, IObject)>();
        private ObjectsManager objectsManager;
        private ObjectLoader objectLoader;
        public DynamicLoader(ObjectsManager objectsManager, ObjectLoader objectLoader) {
            this.objectsManager = objectsManager;
            this.objectLoader = objectLoader;
        }
        public void Initialize()
        {
            staticObjects.Clear();
            dynamicObjects.Clear();
            nonCollidableObjects.Clear();
            var staticList = objectLoader.Statics;
            var dynamicList = objectLoader.Dynamics;
            var nonCollidableList = objectLoader.NonCollidables;
            objectsManager.SetMario(objectLoader.Mario);
            staticList.ForEach(obj => staticObjects.Add((obj.Position.X, obj)));
            dynamicList.ForEach(obj => dynamicObjects.Add((obj.Position.X, obj)));
            nonCollidableList.ForEach(obj => nonCollidableObjects.Add((obj.Position.X, obj)));
            //Because here it made a copy, no need to worry about 
            staticObjects.Sort((o1, o2) => (floatComparison(o1.Item1, o2.Item1)));
            dynamicObjects.Sort((o1, o2) => (floatComparison(o1.Item1, o2.Item1)));
            nonCollidableObjects.Sort((o1, o2) => (floatComparison(o1.Item1, o2.Item1)));
        }
        private int floatComparison(float f1, float f2)
        {
            //Used three times so not a good practice to use lambda.
            if (f1 > f2) return 1;
            if (f1 < f2) return -1;
            return 0;
        }
        public void Load(float rightBound)
        {
            while (staticObjects.Count > 0 && staticObjects.First().Item1 < rightBound)
            {
                objectsManager.AddObject(staticObjects.First().Item2);
                staticObjects.RemoveAt(0);
            }
            while (dynamicObjects.Count > 0 && dynamicObjects.First().Item1 < rightBound)
            {
                objectsManager.AddObject(dynamicObjects.First().Item2);
                dynamicObjects.RemoveAt(0);
            }
            while (nonCollidableObjects.Count > 0 && nonCollidableObjects.First().Item1 < rightBound)
            {
                objectsManager.AddNonCollidableObject(nonCollidableObjects.First().Item2);
                nonCollidableObjects.RemoveAt(0);
            }
        }
    }
}
