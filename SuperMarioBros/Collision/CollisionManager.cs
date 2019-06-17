using SuperMarioBros.Items;
using SuperMarioBros.Objects;
using System;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Collisions
{
    public class CollisionManager 
    {
        private readonly Collection<IStatic> staticObjects;
        private readonly Collection<IDynamic> dynamicObjects;
        public CollisionManager()
        {
            staticObjects = ObjectLoading.LoadStatics();
            dynamicObjects = ObjectLoading.LoadDynamics();
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
                for(int j = i + 1; j < dynamicObjects.Count; j++)
                {
                    Direction direction = CollisionDetection.Detect(dynamicObjects[i], dynamicObjects[j]);
                    if (direction != Direction.none)
                        DynamicAndDynamicObjectsHandler.HandleCollision(dynamicObjects[i], dynamicObjects[j], direction);
                }
            }
        }
    }
}
