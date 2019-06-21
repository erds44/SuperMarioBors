using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioBros.Loading
{
    public class DynamicLoading
    {
        private List<(float, IStatic)> staticObjects = new List<(float, IStatic)>();
        private List<(float, IDynamic)> dynamicObjects = new List<(float, IDynamic)>();
        private List<(float, IObject)> nonCollidableObjects = new List<(float, IObject)>();
        public static DynamicLoading Instance
        {
            get
            {
                if (instance is null) instance = new DynamicLoading();
                return instance;
            }
        }
        private static DynamicLoading instance;
        private DynamicLoading() { }
        public void Initialize()
        {
            staticObjects.Clear();
            dynamicObjects.Clear();
            nonCollidableObjects.Clear();
            var staticList = ObjectLoading.LoadStatics();
            var dynamicList = ObjectLoading.LoadDynamics();
            var nonCollidableList = ObjectLoading.LoadNonCollidable();
            ObjectsManager.Instance.SetMario(ObjectLoading.mario);
            staticList.ForEach(obj => { staticObjects.Add((obj.Position.X, obj)); });
            dynamicList.ForEach(obj => {dynamicObjects.Add((obj.Position.X, obj)); });
            nonCollidableList.ForEach(obj => {nonCollidableObjects.Add((obj.Position.X, obj));});
            staticObjects.Sort((o1, o2) => (floatComparison(o1.Item1, o2.Item1)));
            dynamicObjects.Sort((o1, o2) => (floatComparison(o1.Item1, o2.Item1)));
            nonCollidableObjects.Sort((o1, o2) => (floatComparison(o1.Item1, o2.Item1)));
        }
        private int floatComparison(float f1, float f2)
        {
            if (f1 > f2) return 1;
            if (f1 < f2) return -1;
            return 0;
        }
        public void Load()
        {
            while (staticObjects.Count > 0 && staticObjects.First().Item1 < Camera.Instance.RightBound + 100)
            {
                ObjectsManager.Instance.AddObject(staticObjects.First().Item2);
                staticObjects.RemoveAt(0);
            }
            while (dynamicObjects.Count > 0 && dynamicObjects.First().Item1 < Camera.Instance.RightBound + 100)
            {
                ObjectsManager.Instance.AddObject(dynamicObjects.First().Item2);
                dynamicObjects.RemoveAt(0);
            }
            while (nonCollidableObjects.Count > 0 && nonCollidableObjects.First().Item1 < Camera.Instance.RightBound + 100)
            {
                ObjectsManager.Instance.AddNonCollidable(nonCollidableObjects.First().Item2);
                nonCollidableObjects.RemoveAt(0);
            }
        }
    }
}
