using Microsoft.Xna.Framework;
using SuperMarioBros.Commands;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperMarioBros.Collisions
{
    public static class MarioItemCollisionHandler
    {
        private static Dictionary<Type, Type> collisionDictionary = new Dictionary<Type, Type>
        {
            { typeof(RedMushroom), typeof(RedMushroomCommand) },
            { typeof(GreenMushroom), typeof(GreenMushroomCommand) },
            { typeof(Pipe), typeof(ObstacleCommand) },
            { typeof(Coin), typeof(CoinCommand) },
            { typeof(Flower), typeof(FlowerCommand) }
        };
        public static bool HandleCollision(IMario mario, IItem item, Direction direction)
        {
            if (direction != Direction.none)
            {
                if (collisionDictionary.TryGetValue(item.GetType(), out Type type))
                {
                    ((ICommand)Activator.CreateInstance(type, mario)).Execute();
                    if(item is Pipe)
                    {
                        return false;
                    }
                    return true;
                }
            }
       
            return false;
        }
    }
}
