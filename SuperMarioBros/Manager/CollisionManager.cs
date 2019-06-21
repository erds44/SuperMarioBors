using SuperMarioBros.Collisions;
using SuperMarioBros.Objects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Managers
{
    public class CollisionManager 
    {
        private readonly List<IStatic> staticObjects;
        private readonly List<IDynamic> dynamicObjects;
        public CollisionManager()
        {
            staticObjects = ObjectsManager.Instance.staticObjects;
            dynamicObjects = ObjectsManager.Instance.dynamicObjects;
        }

        public void HandleCollision()
        {
            for (int i = 0; i < dynamicObjects.Count; i++)
            {
                for (int j = 0; j < staticObjects.Count; j++)
                {
                    Direction direction = CollisionDetection.Detect(dynamicObjects[i], staticObjects[j]);
                    if (direction != Direction.none)
                        DynamicAndStaticObjectsHandler.HandleCollision(dynamicObjects[i],staticObjects[j], direction);
                }
                for(int j = i+1; j < dynamicObjects.Count; j++)
                {
                    Direction direction = CollisionDetection.Detect(dynamicObjects[i], dynamicObjects[j]);
                    if (direction != Direction.none)
                        DynamicAndDynamicObjectsHandler.HandleCollision(dynamicObjects[i], dynamicObjects[j], direction);                
                }
            }
        }
    }
}
