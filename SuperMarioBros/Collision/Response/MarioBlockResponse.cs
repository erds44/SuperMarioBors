using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Blocks;
using SuperMarioBros.GameStates;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class MarioBlockResponse : GeneralResponse
    {
        private readonly IMario mario;
        private readonly IBlock block;
        private readonly Direction direction;
        private delegate void MarioBlockHandler(IMario mario, IBlock block);

        public MarioBlockResponse(IObject mario, IObject block, Direction direction)
        {
            this.mario = (IMario)mario;
            this.block = (IBlock)block;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if (MarioGame.Instance.State is FlagPoleState && direction == Direction.top)
            {
                if (block is RockBlock)
                    mario.Right();
                OnGround(mario);
                ResolveOverlap(mario, block, Direction.top);
            }
            else
            {
                if (block is HiddenBlock)
                    MarioVsHiddenBlock(mario, block, direction);
                else if (block is TeleportPipe || block is TeleportHugePipeH)
                    MarioVsTeleportPipe(mario, block, direction);
                else
                {
                    ResolveOverlap(mario, block, direction);
                    switch (direction)
                    {
                        case Direction.top:
                            OnGround(mario);
                            break;
                        case Direction.bottom:
                            GroundOrTopBounce(mario);
                            handlerDictionary.TryGetValue(block.GetType(), out var handler);
                            handler?.Invoke(mario, block);
                            break;
                        default: LeftOrRightBlock(mario); break;
                    }
                }
            }
        }
        private readonly Dictionary<Direction, Keys> keyDictionary = new Dictionary<Direction, Keys>
        {
            { Direction.top, Keys.Down},
            { Direction.left, Keys.Right},
            { Direction.bottom, Keys.Up},
            { Direction.right, Keys.Left},
        };
        private void MarioVsTeleportPipe(IMario mario, IBlock block, Direction direction)
        {
            if (block is TeleportPipe pipe)
            {


                if (!pipe.Teleported)
                {
                    keyDictionary.TryGetValue(direction, out Keys key);
                    if (direction == pipe.TeleportDirection && Keyboard.GetState().IsKeyDown(key))
                    {
                        mario.Teleport(pipe.TransferedLocation, ReverseDirection(direction));
                        pipe.Teleported = true;
                    }
                    else
                    {
                        ResolveOverlap(mario, block, direction);
                        switch (direction)
                        {
                            case Direction.top: OnGround(mario); break;
                            case Direction.bottom: GroundOrTopBounce(mario); break;
                            default: LeftOrRightBlock(mario); break;
                        }
                    }
                }
            }else if(block is TeleportHugePipeH pipeH)
            {
                if (!pipeH.Teleported)
                {
                    keyDictionary.TryGetValue(direction, out Keys key);
                    if (direction == pipeH.TeleportDirection && Keyboard.GetState().IsKeyDown(key))
                    {
                        mario.Teleport(pipeH.TransferedLocation, ReverseDirection(direction));
                        pipeH.Teleported = true;
                    }
                    else
                    {
                        ResolveOverlap(mario, block, direction);
                        switch (direction)
                        {
                            case Direction.top: OnGround(mario); break;
                            case Direction.bottom: GroundOrTopBounce(mario); break;
                            default: LeftOrRightBlock(mario); break;
                        }
                    }
                }
            }
        }

        private readonly Dictionary<Type, MarioBlockHandler> handlerDictionary = new Dictionary<Type, MarioBlockHandler>
        {
            {typeof(BrickBlock), MarioVsBrickBlock},
            {typeof(ItemBrickBlock), MarioVsItemBrickOrQuestionBlock},
            {typeof(QuestionBlock), MarioVsItemBrickOrQuestionBlock},
             /* Other blocks not listed here are teated as rockblock */
        };
        protected override void OnGround(IObject obj)
        {
            if (mario.Physics.Jump)
            {
                if (mario.Physics.JumpKeyUp)
                {
                    mario.Physics.JumpKeyUp = false;
                    mario.Physics.Jump = false;
                }
                ((IMario)obj).MovementState.OnGround();
                mario.Physics.ApplyGravity();
            }
            base.OnGround(obj);
        }
        private static void MarioVsBrickBlock(IMario mario, IBlock block)
        {
            if (mario.HealthState is SmallMario)
                block.Bumped();
            else
            {
                block.Borken();
                ObjectFactory.Instance.CreateBlockDebris(block.Position);
            }
        }

        private static void MarioVsItemBrickOrQuestionBlock(IMario mario, IBlock block)
        {
            if (block.ItemType != null)
            {
                block.Bumped();
                ObjectFactory.Instance.CreateNonCollidableObject(block.ItemType, block.Position);
            }
            else
            {
                block.Used();
                if (mario.HealthState is SmallMario)
                    ObjectFactory.Instance.CreateNonCollidableObject(typeof(RedMushroom), block.Position);
                else
                    ObjectFactory.Instance.CreateNonCollidableObject(typeof(Flower), block.Position);
            }
            if (block.ObjState == ObjectState.Destroy)
                ObjectFactory.Instance.CreateCollidableObject(typeof(UsedBlock), block.Position);
        }

        private static void MarioVsHiddenBlock(IMario mario, IBlock block, Direction direction)
        {
            if (mario.Physics.Velocity.Y < 0)
            {
                GroundOrTopBounce(mario);
                block.Used();
                if (block.ItemType != null)
                    ObjectFactory.Instance.CreateNonCollidableObject(block.ItemType, block.Position);
                else
                {
                    if (mario.HealthState is SmallMario)
                        ObjectFactory.Instance.CreateNonCollidableObject(typeof(RedMushroom), block.Position);
                    else
                        ObjectFactory.Instance.CreateNonCollidableObject(typeof(Flower), block.Position);
                }
                ObjectFactory.Instance.CreateCollidableObject(typeof(UsedBlock), block.Position);
                ResolveOverlap(mario, block, direction);
            }
        }
    }
}
