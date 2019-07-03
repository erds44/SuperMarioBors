using SuperMarioBros.HeadsUps;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
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
        private readonly HeadsUp headsUp;
        public DynamicLoader(ObjectsManager objectsManager, ObjectLoader objectLoader, HeadsUp headsUp) {
            this.objectsManager = objectsManager;
            this.objectLoader = objectLoader;
            this.headsUp = headsUp;
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
                IDynamic obj = dynamicObjects.First().Item2;
                if (obj is IEnemy)
                    ((IEnemy)obj).StompedEvent += headsUp.EnemyStomped; //Initialize this event to the enemy.
                else if (obj is Flag)
                {
                    objectLoader.Mario.SlidingEvent += ((Flag)obj).Sliding;
                    ((Flag)obj).MarioJumpingOffFlagEvent += objectLoader.Mario.JumpingOffFlag;
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
