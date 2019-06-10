using SuperMarioBros.Blocks;
using SuperMarioBros.Commands;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class MarioBlockCollisionHandler 
    {
        private static readonly Dictionary<(Type, Direction), (Type, Type)> collisionDictionary = new Dictionary<(Type, Direction), (Type, Type)>
        {
            {(typeof(UsedBlock), Direction.bottom), (typeof(ObstacleCommand), typeof(Nullable))},
            { (typeof(BrickBlock), Direction.bottom), (typeof(Nullable), typeof(DisappearCommand))},
            {(typeof(QuestionBlock), Direction.bottom), (typeof(ObstacleCommand), typeof(BlockUsedCommand))},
            {(typeof(HiddenBlock), Direction.bottom), (typeof(Nullable), typeof(HiddenBlockUsedCommand))},
            {(typeof(ConcreteBlock), Direction.bottom), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(RockBlock), Direction.bottom), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(UsedBlock), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            { (typeof(ConcreteBlock), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(RockBlock), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(QuestionBlock), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            { (typeof(BrickBlock), Direction.top), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(UsedBlock), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            { (typeof(ConcreteBlock), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(RockBlock), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(QuestionBlock), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            { (typeof(BrickBlock), Direction.left), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(UsedBlock), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))},
            { (typeof(ConcreteBlock), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(RockBlock), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))},
            {(typeof(QuestionBlock), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))},
            { (typeof(BrickBlock), Direction.right), (typeof(ObstacleCommand), typeof(Nullable))}
        };

        public static void HandleCollision(IObject mario, IObject block, Direction direction, int index)
        {
            if (collisionDictionary.TryGetValue((block.GetType(), direction), out var type)) 
            {
                Type typ1 = type.Item1;
                Type typ2 = type.Item2;
                if (typ1 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ1, (IMario)mario)).Execute();
                }
                if (typ2 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ2, (IBlock)block, index)).Execute();
                }
            }
        }
        
    }
}
