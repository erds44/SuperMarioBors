using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.Objects;
using System.Collections.Generic;

namespace SuperMarioBros.Managers
{
    public class CollisionManager 
    {
        private readonly IHandler staticHandler;
        private readonly IHandler dynamicHandler;
        public CollisionManager()
        {
            staticHandler = new DynamicAndStaticObjectsHandler();
            dynamicHandler = new DynamicAndDynamicObjectsHandler();
        }

        private void HandleCollision(IDynamic obj1, IDynamic obj2)
        {
            Direction direction = Detect(obj1, obj2);
            if (direction == Direction.none) return;
            dynamicHandler.HandleCollision(obj1, obj2, direction);
        }

        private void HandleCollision(IDynamic obj1, IStatic obj2)
        {
            Direction direction = Detect(obj1, obj2);
            if (direction == Direction.none) return;
            staticHandler.HandleCollision(obj1, obj2, direction);
        }

        private static Direction Detect(IObject object1, IObject object2)
        {
            if (!(object1.HitBox().Intersects(object2.HitBox()))) return Direction.none;
            Rectangle overlap = Rectangle.Intersect(object1.HitBox(), object2.HitBox());
            if (overlap.Height <= overlap.Width)
            {
                if (overlap.Center.Y >= object2.HitBox().Center.Y) return Direction.bottom;
                if (overlap.Center.Y < object2.HitBox().Center.Y) return Direction.top;
            }
            else
            {
                if (overlap.Center.X >= object2.HitBox().Center.X) return Direction.right;
                if (overlap.Center.X < object2.HitBox().Center.X) return Direction.left;
            }
            return Direction.none;
        }

        public void Update()
        {
            List<IDynamic> dynamicObjects = MarioGame.Instance.ObjectsManager.DynamicObjects;
            List<IStatic> staticObjects = MarioGame.Instance.ObjectsManager.StaticObjects;
            for (int i = 0; i < dynamicObjects.Count; i++)
            {
                for (int j = 0; j < staticObjects.Count; j++)
                {
                    HandleCollision(dynamicObjects[i],staticObjects[j]);
                }
                for(int j = i+1; j < dynamicObjects.Count; j++)
                {
                    if (i >= dynamicObjects.Count) break;
                    HandleCollision(dynamicObjects[i], dynamicObjects[j]);                
                }
            }
        }
    }
}
