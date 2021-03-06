﻿using SuperMarioBros.HeadsUps;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Utility;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioBros.Loading
{
    public class DynamicLoader
    {
        //This is just a buffer -- Load objects in a "effective" range. This could reduce memory use.
        private readonly List<(float, IStatic)> staticObjects = new List<(float, IStatic)>();
        private readonly List<(float, IDynamic)> dynamicObjects = new List<(float, IDynamic)>();
        private readonly List<(float, IObject)> nonCollidableObjects = new List<(float, IObject)>();
        private readonly ObjectsManager objectsManager;
        private readonly ObjectLoader objectLoader;
      //  private readonly HeadsUpDisplay headsUp;
        private readonly MarioGame game;
        public DynamicLoader(MarioGame game , ObjectLoader objectLoader, ObjectsManager objectsManager) {
            this.objectsManager = objectsManager;
            this.objectLoader = objectLoader;
           // headsUp = game.HeadsUps;
            this.game = game;
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
            staticObjects.Sort((o1, o2) => (FloatComparison(o1.Item1, o2.Item1)));
            dynamicObjects.Sort((o1, o2) => (FloatComparison(o1.Item1, o2.Item1)));
            nonCollidableObjects.Sort((o1, o2) => (FloatComparison(o1.Item1, o2.Item1)));
        }
        private static int FloatComparison(float f1, float f2)
        {
            //Used three times so not a good practice to use lambda.
            if (f1 > f2) return GeneralConstants.Greater;
            if (f1 < f2) return GeneralConstants.Less;
            return GeneralConstants.Equal;
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
                IDynamic obj = dynamicObjects.First().Item2;
                if (obj is Flag flag)
                {
                    game.Player.SlidingEvent += flag.Sliding;
                    flag.MarioJumpingOffFlagEvent += game.Player.JumpingOffFlag;
                }
                objectsManager.AddObject(obj);
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
