using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Commands;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class MarioBlockCollisionHandler 
    {

        private static readonly Dictionary<(Type, Type,Direction), MarioBlockHandler> handlerDictionary = new Dictionary<(Type, Type,Direction), MarioBlockHandler>
        {
            {(typeof(BigMario),typeof(UsedBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(UsedBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(UsedBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(UsedBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            //bigmario unchanged for brickblock
            {(typeof(BigMario),typeof(BrickBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(BrickBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(BrickBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(BrickBlockState),Direction.bottom),new MarioBlockHandler(MarioUnchangedBlockUsed)},
            {(typeof(BigMario),typeof(RockBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(RockBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(RockBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(RockBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(ConcreteBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(ConcreteBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(ConcreteBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(ConcreteBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(QuestionBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(QuestionBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(QuestionBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(BigMario),typeof(QuestionBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUsed)},
            {(typeof(BigMario),typeof(HiddenBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUsed)},
            {(typeof(FireMario),typeof(UsedBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(UsedBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(UsedBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(UsedBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            //firemario unchanged for brickblock
            {(typeof(FireMario),typeof(BrickBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(BrickBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(BrickBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(BrickBlockState),Direction.bottom),new MarioBlockHandler(MarioUnchangedBlockUsed)},
            {(typeof(FireMario),typeof(RockBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(RockBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(RockBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(RockBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(ConcreteBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(ConcreteBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(ConcreteBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(ConcreteBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(QuestionBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(QuestionBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(QuestionBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(FireMario),typeof(QuestionBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUsed)},
            {(typeof(FireMario),typeof(HiddenBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUsed)},
            {(typeof(SmallMario),typeof(UsedBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(UsedBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(UsedBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(UsedBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(BrickBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(BrickBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(BrickBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(BrickBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockBumped)},
            {(typeof(SmallMario),typeof(RockBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(RockBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(RockBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(RockBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(ConcreteBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(ConcreteBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(ConcreteBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(ConcreteBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(QuestionBlockState),Direction.top),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(QuestionBlockState),Direction.left),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(QuestionBlockState),Direction.right),new MarioBlockHandler(MarioObstacleBlockUnchanged)},
            {(typeof(SmallMario),typeof(QuestionBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUsed)},
            {(typeof(SmallMario),typeof(HiddenBlockState),Direction.bottom),new MarioBlockHandler(MarioObstacleBlockUsed)}

        };
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

        public static void HandleCollisionV1(IObject mario, IBlock Block, Direction direction)
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
        public static void HandleCollision(IMario mario, IBlock Block, Direction direction)
        {
            if (handlerDictionary.TryGetValue((mario.HealthState.GetType(), Block.State.GetType(), direction),out var handler)){
                handler(mario, Block);
            }
        }

        private delegate void MarioBlockHandler(IMario mario, IBlock block);

        private static void MarioObstacleBlockUnchanged(IMario mario, IBlock block)
        {
            mario.Obstacle();
        }
        private static void MarioUnchangedBlockUsed(IMario mario, IBlock block)
        {
            block.Used();
        }

        private static void MarioObstacleBlockUsed(IMario mario,IBlock block)
        {
            mario.Obstacle();
            block.Used();
        }

        //Bumped will be added later
        private static void MarioObstacleBlockBumped(IMario mario, IBlock block)
        {
            mario.Obstacle();
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
