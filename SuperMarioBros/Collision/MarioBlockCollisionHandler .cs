using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Commands;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class MarioBlockCollisionHandler
    {
        /* All CollisionHandler class will be refactored using delegate */
        private static readonly Dictionary<(Type, Direction), (Type, Type)> collisionDictionary = new Dictionary<(Type, Direction), (Type, Type)>
        {
            {(typeof(BrickBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(ConcreteBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(QuestionBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(RockBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
            {(typeof(UsedBlockState), Direction.top), (typeof(MoveMarioUpCommand), typeof(Nullable))},
           // {(typeof(HiddenBlockState), Direction.top), (typeof(MoveMarioDownCommand), typeof(Nullable))},

            {(typeof(BrickBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(ConcreteBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(QuestionBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(RockBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
            {(typeof(UsedBlockState), Direction.left), (typeof(MoveMarioLeftCommand), typeof(Nullable))},
           // {(typeof(HiddenBlockState), Direction.left), (typeof(MoveMarioRightCommand), typeof(Nullable))},

            {(typeof(BrickBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(ConcreteBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(QuestionBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(RockBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            {(typeof(UsedBlockState), Direction.right), (typeof(MoveMarioRightCommand), typeof(Nullable))},
            //{(typeof(HiddenBlockState), Direction.right), (typeof(MoveMarioLeftCommand), typeof(Nullable))},

            {(typeof(BrickBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(DisappearCommand))},
            {(typeof(ConcreteBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(Nullable))},
            {(typeof(QuestionBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(BlockUsedCommand))},
            {(typeof(RockBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(Nullable))},
            {(typeof(UsedBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(Nullable))},
            //{(typeof(HiddenBlockState), Direction.bottom), (typeof(MoveMarioDownCommand), typeof(BlockUsedCommand))},





        };

        public static void HandleCollision(IObject mario, IBlock Block, Direction direction)
        {
            if (collisionDictionary.TryGetValue((Block.State.GetType(), direction), out var type))
            {

                Type typ1 = type.Item1;
                Type typ2 = type.Item2;
                if (typ1 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ1, (IMario)mario)).Execute();
                }
                if (typ2 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ2, (IBlock)Block)).Execute();
                }
            }
        }
        //private delegate void MarioBlockHandler(IMario mario, IBlock block, Direction direction);
        //private static void MarioObstacleAndBlockUsed(IMario mario, IBlock block, Direction direction)
        //{
        //    // work for Mario vs Question / Hidden
        //    mario.Obstacle();
        //    if (direction == Direction.bottom)
        //    {
        //        block.Used();
        //    }
        //}
        //private static void MarioObstacleAndBlockBumped(IMario mario, IBlock block, Direction direction)
        //{
        //    // work for smallMario vs Brick
        //}
        //private static void MarioObstacleAndBlockBroken(IMario mario, IBlock block, Direction direction)
        //{
        //    // work for big/fire Mario vs Brick
        //}
        //private static void MarioObstacle(IMario mario, IBlock block, Direction direction)
        //{
        //    // work for big/fire Mario vs rock, concrete, used block
        //}
        //private static Dictionary<(Type, Type), MarioBlockHandler> handler = new Dictionary<(Type, Type), MarioBlockHandler>
        //{
        //    // Different cases to add
        //};
    }
}
