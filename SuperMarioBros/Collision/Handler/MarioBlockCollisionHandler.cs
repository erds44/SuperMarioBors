﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Utility;
using System;
using static SuperMarioBros.Utility.StringConsts;

namespace SuperMarioBros.Collisions
{
    public class MarioBlockCollisionHandler : GeneralHandler
    {
        /* This class deals mainly with the bottom collision agaisnt block
         * Rest sides collision heandlers are in GeneralHandler
         */
        private static bool flagePoleStage = false;
        public static void SmallMarioVsHidden(IMario mario, IBlock block, Direction direction) 
        {
            if (mario.Physics.Velocity.Y < 0)
            {
                MoverVerticallyBounce(mario,block,direction);
                block.Used();
                AudioFactory.Instance.CreateSound(Bump).Play();
                if (block.ItemType != null)
                    GenerateItemInBlock(block.ItemType, block.Position);
                else
                    GenerateRedMushroom(block.Position);

                GenerateUsedBlock(block.Position);
                ResolveOverlap(mario, block, direction);
            }
        }
        public static void BigOrFireMarioVsHidden(IMario mario, IBlock block, Direction direction)
        {
            if (mario.Physics.Velocity.Y < 0)
            {
                MoverVerticallyBounce(mario, block, direction);
                block.Used();
                AudioFactory.Instance.CreateSound(Bump).Play();

                if (block.ItemType != null)
                    GenerateItemInBlock(block.ItemType, block.Position);
                else
                    GenerateFlower(block.Position);

                GenerateUsedBlock(block.Position);
                ResolveOverlap(mario, block, direction);
            }
        }
        public static void MarioOnGround(IMario mario, IBlock block, Direction direction)
        {
            if (mario.Physics.Jump)
            {
                if (mario.Physics.JumpKeyUp)
                {
                    mario.Physics.JumpKeyUp = false;
                    mario.Physics.Jump = false;
                }
                mario.MovementState.OnGround();
                mario.Physics.ApplyGravity();
            }
            MoverOnGround(mario, block, direction);
        }
        public static void MarioOnGroundOrMoveRight(IMario mario, IBlock block, Direction direction)
        {
            if (mario.MovementState is LeftSliding)
            {
                flagePoleStage = true;
                MediaPlayer.Stop();
                MediaPlayer.Play(AudioFactory.Instance.CreateSong(LevelComplete));
                mario.ClearingScoresEvent += ResetFlagPoleStage;
            }
            if (flagePoleStage)
                mario.MoveRight();
            MarioOnGround(mario, block, direction);
        }

        public static void SmallMarioVsBrickBlock(IMario mario, IBlock block, Direction direction)
        {
            if (block.CanBeBumped)
            {
                block.Bumped();
                AudioFactory.Instance.CreateSound(Bump).Play();
                MoverVerticallyBounce(mario, block, direction);
            }
            else
                ResolveOverlap(mario, block, direction);
        }
        public static void BigOrFireMarioVsBrickBlock(IMario mario, IBlock block, Direction direction)
        {
            if (block.CanBeBumped)
            {
                block.Broken();
                AudioFactory.Instance.CreateSound(BlockBreak).Play();
                ObjectFactory.Instance.CreateBlockDebris(block.Position, block.GetType());
                MoverVerticallyBounce(mario, block, direction);
            }
            else
                ResolveOverlap(mario, block, direction);
        }

        public static void SmallMarioVsQuestionOrItemBrickBlock(IMario mario, IBlock block, Direction direction)
        {
            if(block.ItemType != null)
            {
                block.Bumped();
                GenerateItemInBlock(block.ItemType, block.Position);
                AudioFactory.Instance.CreateSound(Bump).Play();
            }
            else
            {
                block.Used();
                GenerateRedMushroom(block.Position);
            }
            if (block.ObjState == ObjectState.Destroy)
                GenerateUsedBlock(block.Position);
            MoverVerticallyBounce(mario, block, direction);
        }

        public static void BigOrFireMarioVsQuestionOrItemBrickBlock(IMario mario, IBlock block, Direction direction)
        {
            if (block.ItemType != null)
            {
                block.Bumped();
                GenerateItemInBlock(block.ItemType, block.Position);
                AudioFactory.Instance.CreateSound(Bump).Play();
            }
            else
            {
                block.Used();
                GenerateFlower(block.Position);
            }
            if (block.ObjState == ObjectState.Destroy)
                GenerateUsedBlock(block.Position);
            MoverVerticallyBounce(mario, block, direction);
        }
        public static void MarioVsUsedBlock(IMario mario, IBlock block, Direction direction)
        {
            AudioFactory.Instance.CreateSound(Bump).Play();
            MoverVerticallyBounce(mario, block, direction);
        }

        private static void GenerateItemInBlock(Type type, Vector2 position)
        {
            ObjectFactory.Instance.CreateNonCollidableObject(type, position);
        }
        private static void GenerateRedMushroom(Vector2 position)
        {
            ObjectFactory.Instance.CreateNonCollidableObject(typeof(RedMushroom), position);
            AudioFactory.Instance.CreateSound(Power).Play();
        }
        private static void GenerateFlower(Vector2 position)
        {
            ObjectFactory.Instance.CreateNonCollidableObject(typeof(Flower), position);
            AudioFactory.Instance.CreateSound(Power).Play();
        }
        private static void GenerateUsedBlock(Vector2 position)
        {
            ObjectFactory.Instance.CreateCollidableObject(typeof(UsedBlock), position);
        }
        public static void ResetFlagPoleStage(object sender, EventArgs e)
        {
            flagePoleStage = false;
        }
    }
}
