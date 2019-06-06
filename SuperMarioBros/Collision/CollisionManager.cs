using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Collisions
{
    public class CollisionManager 
    {
        public IMario Mario { get; set; }
        private readonly List<IObject> objects;
        public CollisionManager( IMario mario, List<IObject> objects)
        {
            this.Mario = mario;
            this.objects = objects;
        }

        public void HandleCollision()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                Direction direction = CollisionDetection.Detect(Mario, objects[i]);
                if (objects[i] is IItem)
                {
                    MarioItemCollisionHandler.HandleCollision(Mario, (IItem)objects[i], direction, i);
                }else if(objects[i] is IEnemy)
                {
                   MarioEnemyCollisionHandler.HandleCollision(Mario,  (IEnemy)objects[i], direction, i);
                } 
                else
                {
                    MarioBlockCollisionHandler.HandleCollision(Mario, (IBlock)objects[i], direction, i);
                }
            }
        }
    }
}
