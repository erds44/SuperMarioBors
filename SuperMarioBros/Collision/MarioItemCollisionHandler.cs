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
        private static readonly Dictionary<(Type, Direction), (Type, Type)> collisionDictionary = new Dictionary<(Type,Direction), (Type, Type)>
        {
            {(typeof(RedMushroom), Direction.top), (typeof(RedMushroomCommand), typeof(DisappearCommand))},
            {(typeof(GreenMushroom), Direction.top), (typeof(GreenMushroomCommand), typeof(DisappearCommand))},
            {(typeof(Pipe), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(Coin), Direction.top), (typeof(CoinCommand), typeof(DisappearCommand))},
            {(typeof(Flower), Direction.top), (typeof(FlowerCommand), typeof(DisappearCommand))},
            {(typeof(Star), Direction.top), (typeof(StarMarioCommand), typeof(DisappearCommand))},

            {(typeof(RedMushroom), Direction.bottom), (typeof(RedMushroomCommand), typeof(DisappearCommand))},
            {(typeof(GreenMushroom), Direction.bottom), (typeof(GreenMushroomCommand), typeof(DisappearCommand))},
            {(typeof(Pipe), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(Nullable))},
            {(typeof(Coin), Direction.bottom), (typeof(CoinCommand), typeof(DisappearCommand))},
            {(typeof(Flower), Direction.bottom), (typeof(FlowerCommand), typeof(DisappearCommand))},
            {(typeof(Star), Direction.bottom), (typeof(StarMarioCommand), typeof(DisappearCommand))},

            {(typeof(RedMushroom), Direction.left), (typeof(RedMushroomCommand), typeof(DisappearCommand))},
            {(typeof(GreenMushroom), Direction.left), (typeof(GreenMushroomCommand), typeof(DisappearCommand))},
            {(typeof(Pipe), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(Coin), Direction.left), (typeof(CoinCommand), typeof(DisappearCommand))},
            {(typeof(Flower), Direction.left), (typeof(FlowerCommand), typeof(DisappearCommand))},
            {(typeof(Star), Direction.left), (typeof(StarMarioCommand), typeof(DisappearCommand))},

            {(typeof(RedMushroom), Direction.right), (typeof(RedMushroomCommand), typeof(DisappearCommand))},
            {(typeof(GreenMushroom), Direction.right), (typeof(GreenMushroomCommand), typeof(DisappearCommand))},
            {(typeof(Pipe), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(Coin), Direction.right), (typeof(CoinCommand), typeof(DisappearCommand))},
            {(typeof(Flower), Direction.right), (typeof(FlowerCommand), typeof(DisappearCommand))},
            {(typeof(Star), Direction.right), (typeof(StarMarioCommand), typeof(DisappearCommand))},

        };
        public static void HandleCollision(IObject mario, IObject item, Direction direction)
        {
            if (direction != Direction.none)
            {
                if (collisionDictionary.TryGetValue((item.GetType(), direction), out var tuple))
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
    }
}
