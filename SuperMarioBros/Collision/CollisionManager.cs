using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using SuperMarioBros.Blocks;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Collisions
{
    public class CollisionManager 
    {
        private readonly Collection<IObject> staticObjects;
        private readonly Collection<IMario> mario;
        public CollisionManager()
        {
            staticObjects = ObjectLoading.LoadObject();
            mario = ObjectLoading.LoadMario();
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
                        MarioItemCollisionHandler.HandleCollision(mario[j], staticObjects[i], direction);
                    }
                    else if (staticObjects[i] is IEnemy)
                    {
                        MarioEnemyCollisionHandler.HandleCollision(mario[j], staticObjects[i], direction);
                    }
                    else if (staticObjects[i] is IBlock)
                    {                       
                        MarioBlockCollisionHandler.HandleCollision(mario[j], (IBlock)staticObjects[i], direction);
                    }
                }
            }
        }
    }
}
