﻿using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Goombas;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class DynamicAndStaticObjectsHandler
    {

        private delegate void CollisionHandler(IDynamic obj1, IStatic obj2, Direction direction);
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
            if (collisionDictionary.TryGetValue((obj1.GetType(),type), out var handle))
            {
                handle(obj1, obj2, direction);
            }
        }

        private static readonly Dictionary<(Type, Type), CollisionHandler> collisionDictionary = new Dictionary<(Type, Type), CollisionHandler>
        {
            { (typeof(Mario), typeof(BrickBlockState)), MoveMarioBlockBumped},
            { (typeof(Mario), typeof(ConcreteBlockState)), MoveDynamic},
            { (typeof(Mario), typeof(QuestionBlockState)), MoveMarioBlockUsed},
            { (typeof(Mario), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Mario), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Mario), typeof(HiddenBlockState)), HiddenUsed},
            { (typeof(Mario), typeof(Pipe)), MoveDynamic},

            { (typeof(StarMario), typeof(BrickBlockState)), MoveMarioBlockBumped},
            { (typeof(StarMario), typeof(ConcreteBlockState)), MoveDynamic},
            { (typeof(StarMario), typeof(QuestionBlockState)), MoveMarioBlockUsed},
            { (typeof(StarMario), typeof(RockBlockState)), MoveDynamic},
            { (typeof(StarMario), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(StarMario), typeof(HiddenBlockState)), HiddenUsed},
            { (typeof(StarMario), typeof(Pipe)), MoveDynamic},

            { (typeof(FlashingMario), typeof(BrickBlockState)), MoveMarioBlockBumped},
            { (typeof(FlashingMario), typeof(ConcreteBlockState)), MoveDynamic},
            { (typeof(FlashingMario), typeof(QuestionBlockState)), MoveMarioBlockUsed},
            { (typeof(FlashingMario), typeof(RockBlockState)), MoveDynamic},
            { (typeof(FlashingMario), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(FlashingMario), typeof(HiddenBlockState)), HiddenUsed},
            { (typeof(FlashingMario), typeof(Pipe)), MoveDynamic},

            { (typeof(Star), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(Star), typeof(ConcreteBlockState)), MoveDynamic},
            { (typeof(Star), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(Star), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Star), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Star), typeof(Pipe)), MoveDynamic},

            { (typeof(Goomba), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Goomba), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(Goomba), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(Goomba), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Goomba), typeof(Pipe)), MoveDynamic},

            { (typeof(Koopa), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Koopa), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(Koopa), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(Koopa), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Koopa), typeof(Pipe)), MoveDynamic},
        };
        private static void MoveMarioBlockBumped(IDynamic obj1, IStatic obj2 ,Direction direction)
        {
            IMario mario = (IMario)obj1;
            MoveDynamic(obj1, obj2, direction);
            if ((mario.HealthState is SmallMario))
            {
                // Block.Bumped();
            }
            else if(direction == Direction.bottom)
            {
                ObjectsManager.Instance.Remove(obj2);
            }
        }
        private static void MoveMarioBlockUsed(IDynamic obj1, IStatic obj2, Direction direction)
        {
            MoveDynamic(obj1, obj2, direction);
            if(direction == Direction.bottom)
                ((IBlock) obj2).Used();
        }
        private static void MoveDynamic(IDynamic obj1, IStatic obj2, Direction direction)
        {
            switch (direction)
            {
                case Direction.top : obj1.MoveUp(); break;
                case Direction.bottom: obj1.MoveDown(); break;
                case Direction.left: obj1.MoveLeft(); break;
                case Direction.right: obj1.MoveRight(); break;
            }
        }
        private static void HiddenUsed(IDynamic obj1, IStatic obj2, Direction direction)
        {
            if (direction == Direction.bottom)
            {
                if (((IMario)obj1).MarioPhysics.YVelocity < 0)
                {
                    ((IBlock)obj2).Used();
                    MoveDynamic(obj1, obj2, direction);
                }
            }
        }

    }
}