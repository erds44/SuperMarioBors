using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Commands;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class DynamicAndStaticObjectsHandler
    {
        /* All CollisionHandler class will be refactored using delegate */
        /* Hidden to check*/
        private static readonly Dictionary<(Type, Type, Direction), (Type, Type)> collisionDictionary = new Dictionary<(Type, Type, Direction), (Type, Type)>
        {
            {(typeof(Mario), typeof(BrickBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(ConcreteBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(QuestionBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(RockBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(UsedBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(Pipe), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},

            {(typeof(Mario), typeof(BrickBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(ConcreteBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(QuestionBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(RockBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(UsedBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(Pipe), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},

            {(typeof(Mario), typeof(BrickBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(ConcreteBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(QuestionBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(RockBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(UsedBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(Pipe), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},

            {(typeof(Mario), typeof(BrickBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(DisappearCommand))},
            {(typeof(Mario), typeof(ConcreteBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(QuestionBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(BlockUsedCommand))},
            {(typeof(Mario), typeof(RockBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(Nullable))},
            {(typeof(Mario), typeof(UsedBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(Nullable))},
           // {(typeof(Mario), typeof(HiddenBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(HiddenBlockUsedCommand))},
            {(typeof(Mario), typeof(Pipe), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(Nullable))},

            { (typeof(Star), typeof(RockBlockState), Direction.top), (typeof(MoveDynamicUpCommand), typeof(Nullable))},
            { (typeof(Star), typeof(Pipe), Direction.top), (typeof(MoveDynamicUpCommand), typeof(Nullable))},

            { (typeof(Star), typeof(RockBlockState), Direction.bottom), (typeof(MoveDynamicDownCommand), typeof(Nullable))},
            { (typeof(Star), typeof(Pipe), Direction.bottom), (typeof(MoveDynamicDownCommand), typeof(Nullable))},

            { (typeof(Star), typeof(RockBlockState), Direction.left), (typeof(MoveDynamicLeftCommand), typeof(Nullable))},
            { (typeof(Star), typeof(Pipe), Direction.left), (typeof(MoveDynamicLeftCommand), typeof(Nullable))},

            { (typeof(Star), typeof(RockBlockState), Direction.right), (typeof(MoveDynamicRightCommand), typeof(Nullable))},
            { (typeof(Star), typeof(Pipe), Direction.right), (typeof(MoveDynamicRightCommand), typeof(Nullable))}


        };

        public static void HandleCollision(IDynamic obj1, IStatic obj2, Direction direction)
        {
            Type type;
            if (obj2 is IBlock)
            {
                type = ((IBlock)obj2).State.GetType();
            }
            else
            {
                type = obj2.GetType();
            }
            if (collisionDictionary.TryGetValue((obj1.GetType(),type, direction), out var types))
            {
                Type typ1 = types.Item1;
                Type typ2 = types.Item2;
                if (typ1 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ1, obj1)).Execute();
                }
                if (typ2 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ2, obj2)).Execute();
                }
            }
        }
    }
}
