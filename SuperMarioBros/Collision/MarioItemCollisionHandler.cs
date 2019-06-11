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
        private static readonly Dictionary<Type, (Type, Type)> collisionDictionary = new Dictionary<Type, (Type,Type)>
        {
            { typeof(RedMushroom), (typeof(RedMushroomCommand), typeof(DisappearCommand)) },
            { typeof(GreenMushroom), (typeof(GreenMushroomCommand) ,  typeof(DisappearCommand))},
            { typeof(Pipe), (typeof(ObstacleCommand) , typeof(Nullable))},
            { typeof(Coin), (typeof(CoinCommand), typeof(DisappearCommand)) },
            { typeof(Flower), (typeof(FlowerCommand) , typeof(DisappearCommand))},
            { typeof(Star), (typeof(StarMarioCommand) , typeof(DisappearCommand))}
        };
        public static void HandleCollision(IObject mario, IObject item, Direction direction, int objectIndex, int marioIndex)
        {
            if (direction != Direction.none)
            {
                if (collisionDictionary.TryGetValue(item.GetType(), out var tuple))
                {
                    Type typ1 = tuple.Item1;
                    Type typ2 = tuple.Item2;
                    if (typ1 != typeof(Nullable))
                    {
                        if (typ1 == typeof(StarMarioCommand))
                        {
                            ((ICommand)Activator.CreateInstance(typ1, (IMario)mario, marioIndex)).Execute();
                        }
                        else
                        {
                            ((ICommand)Activator.CreateInstance(typ1, (IMario)mario)).Execute();
                        }
                    }
                    if(typ2 != typeof(Nullable))
                    {
                        ((ICommand)Activator.CreateInstance(typ2, (IItem)item, objectIndex)).Execute();
                    }
                }
            }
        }
    }
}
