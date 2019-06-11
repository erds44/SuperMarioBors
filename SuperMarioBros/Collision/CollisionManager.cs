using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using System.Collections.Generic;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Collisions
{
    public class CollisionManager 
    {
        private readonly List<IObject> staticObjects;
        private readonly List<IMario> mario;
        public CollisionManager()
        {
            mario = ObjectsManager.Instance.Mario;
            staticObjects = ObjectsManager.Instance.StaticObjects;
        }

        public void HandleCollision()
        {
            for (int j = 0; j < mario.Count; j++)
            {
                for (int i = 0; i < staticObjects.Count; i++)
                {
                    Direction direction = CollisionDetection.Detect(mario[j], staticObjects[i]);
                    if (staticObjects[i] is IItem)
                    {
                        MarioItemCollisionHandler.HandleCollision(mario[j], staticObjects[i], direction, i, j);
                    }
                    else if (staticObjects[i] is IEnemy)
                    {
                        MarioEnemyCollisionHandler.HandleCollision(mario[j], staticObjects[i], direction, i, j);
                    }
                    else if (staticObjects[i] is IBlock)
                    {
                        MarioBlockCollisionHandler.HandleCollision(mario[j], staticObjects[i], direction, i);
                    }
                }
            }
        }
    }
}
