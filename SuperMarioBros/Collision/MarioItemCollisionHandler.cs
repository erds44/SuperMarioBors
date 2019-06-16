using SuperMarioBros.Commands;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class MarioItemCollisionHandler 
    {
        private static readonly Dictionary<Type, MarioItemHandler> collisionDictionary = new Dictionary<Type, MarioItemHandler>
        {
            { typeof(RedMushroom), new MarioItemHandler(MarioUnchangedRedMushroomDisappear) },
            { typeof(GreenMushroom), new MarioItemHandler(MarioUnchangedGreenMushroomDisappear)},
            { typeof(Pipe), new MarioItemHandler(MarioObstacleItemUnchanged)},
            { typeof(Coin), new MarioItemHandler(MarioUnchangedCoinDisappear)},
            { typeof(Flower), new MarioItemHandler(MarioUnchangedFlowerDisappear)},
            { typeof(Star), new MarioItemHandler(MarioUnchangedStarDisappear)}
        };
      /**  public static void HandleCollisionV1(IObject mario, IObject item, Direction direction)
        {
            if (direction != Direction.none)
            {
                if (collisionDictionary.TryGetValue(item.GetType(), out var tuple))
                {
                    Type typ1 = tuple.Item1;
                    Type typ2 = tuple.Item2;
                    if (typ1 != typeof(Nullable))
                    {
                         ((ICommand)Activator.CreateInstance(typ1, (IMario)mario)).Execute();
                    }
                    if(typ2 != typeof(Nullable))
                    {
                        ((ICommand)Activator.CreateInstance(typ2, (IItem)item)).Execute();
                    }
                }
            }
        }
    */
        public static void HandleCollision(IMario mario, IObject item, Direction direction)
        {
            if (direction != Direction.none)
            {
                if (collisionDictionary.TryGetValue(item.GetType(), out var handler))
                {
                    handler(mario, item);
                }
            }
        }
        private delegate void MarioItemHandler(IMario mario, IObject item);
        private static void MarioObstacleItemUnchanged(IMario mario, IObject item)
        {
            mario.Obstacle();
        }

        private static void MarioUnchangedItemDisappear(IMario mario, IObject item)
        {
            ObjectsManager.Instance.Remove(item);
        }
        private static void MarioUnchangedGreenMushroomDisappear(IMario mario, IObject item)
        {
            mario.GreenMushroom();
            ObjectsManager.Instance.Remove(item);
        }

        private static void MarioUnchangedRedMushroomDisappear(IMario mario, IObject item)
        {
            mario.RedMushroom();
            ObjectsManager.Instance.Remove(item);
        }
        private static void MarioUnchangedCoinDisappear(IMario mario, IObject item)
        {
            mario.Coin();
            ObjectsManager.Instance.Remove(item);
        }

        private static void MarioUnchangedFlowerDisappear(IMario mario, IObject item)
        {
            mario.OnFireFlower();
            ObjectsManager.Instance.Remove(item);
        }

        private static void MarioUnchangedStarDisappear(IMario mario, IObject item)
        {
            ObjectsManager.Instance.StarMario(mario);
            ObjectsManager.Instance.Remove(item);
        }
    }
}
