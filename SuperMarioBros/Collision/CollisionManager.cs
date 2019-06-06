using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class CollisionManager 
    {
        private readonly IMario mario;
        private readonly List<IObject> objects;
        public CollisionManager( IMario mario, List<IObject> objects)
        {
            this.mario = mario;
            this.objects = objects;
        }

        public void HandleCollision()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                Direction direction = CollisionDetection.Detect(mario, objects[i]);
                if (objects[i] is IItem)
                {
                    MarioItemCollisionHandler.HandleCollision(mario, (IItem)objects[i], direction, i);
                }else if(objects[i] is IEnemy)
                {
                   MarioEnemyCollisionHandler.HandleCollision(mario,  (IEnemy)objects[i], direction, i);
                } 
                else
                {
                    // Block 
                }
            }
        }
    }
}
