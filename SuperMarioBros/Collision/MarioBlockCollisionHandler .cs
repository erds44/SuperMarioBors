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
            {(typeof(UsedBlockState), Direction.bottom), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(BrickBlockState), Direction.bottom), (typeof(Nullable), typeof(BrickDisappearCommand))},
            {(typeof(QuestionBlockState), Direction.bottom), (typeof(ObstacleCommand), typeof(BlockUsedCommand))},
            {(typeof(HiddenBlockState), Direction.bottom), (typeof(Nullable), typeof(HiddenBlockUsedCommand))},
            {(typeof(ConcreteBlockState), Direction.bottom), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(RockBlockState), Direction.bottom), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(UsedBlockState), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(ConcreteBlockState), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(RockBlockState), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(QuestionBlockState), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(BrickBlockState), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(UsedBlockState), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(ConcreteBlockState), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(RockBlockState), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(QuestionBlockState), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(BrickBlockState), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(UsedBlockState), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(ConcreteBlockState), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(RockBlockState), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(QuestionBlockState), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(BrickBlockState), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))}
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
        //    // Different caes to add
        //};
    }
}
