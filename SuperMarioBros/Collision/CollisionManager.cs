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
                bool delete = false;
                if (objects[i] is IItem)
                {
                    delete = MarioItemCollisionHandler.HandleCollision(mario, (IItem)objects[i], direction);
                }else if(objects[i] is IEnemy)
                {
                    delete = MarioEnemyCollisionHandler.HandleCollision(mario, (IEnemy)objects[i], direction);
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
