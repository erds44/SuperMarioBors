using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class CollisionManager 
    {
        private readonly IMario mario;
        private readonly List<IObject> objects;
        private readonly ObjectsManager objectsManager;
        public CollisionManager(ObjectsManager objectsManager, IMario mario, List<IObject> objects)
        {
            this.mario = mario;
            this.objects = objects;
            this.objectsManager = objectsManager;
        }

        public void HandleCollision()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                Direction direction = CollisionDetection.Detect(mario, objects[i]);
                bool delete = false;
                if (objects[i] is IItem)
                {
                    delete = MarioItemCollisionHandler.HandleCollision(mario, (IItem)objects[i], direction);
                }else if(objects[i] is IStar)
                {
                    delete = MarioStarCollisionHandler.HandleCollision(objectsManager, mario, (IStar)objects[i], direction);
                } //else if(objects[i] is IEnemy)
                //{
                //    // Eenemy
                //}
                //else
                //{
                //    // Block 
                //}
                if (delete)
                {
                    objects.RemoveAt(i);
                }
            }
        }
    }
}
