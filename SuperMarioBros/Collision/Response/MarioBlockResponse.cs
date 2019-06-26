using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class MarioBlockResponse : GeneralResponse
    {
        private IMario mario;
        private IBlock block;
        private Direction direction;
        private static Vector2 location;
        private delegate void MarioBlockHandler (IMario mario, IBlock block);

        public MarioBlockResponse(IObject mario, IObject block, Direction direction)
        {
            this.mario = (IMario)mario;
            this.block = (IBlock)block;
            this.direction = direction;
            location = block.Position;
        }
        public override void HandleCollision()
        {
            if (block is HiddenBlock)
                MarioVsHiddenBlock(mario, block, direction);
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
        private readonly Dictionary<Type, MarioBlockHandler> handlerDictionary = new Dictionary<Type, MarioBlockHandler>
        {
            {typeof(BrickBlock), MarioVsBrickBlock},
            {typeof(ItemBrickBlock), MarioVsItemBrickOrQuestionBlock},
            {typeof(QuestionBlock), MarioVsItemBrickOrQuestionBlock},
             /* Other blocks not listed here are teated as rockblock */
        };
        protected override void OnGround(IObject obj)
        {
            Physics marioPhysics = obj.Physics;
            if(marioPhysics.Velocity.Y >= 0)
            {
                ((IMario)obj).MovementState.OnGround();
                marioPhysics.ApplyGravity();
                marioPhysics.Jump = false;
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
                GenerateDerbis();
            }
        }

        private static void MarioVsItemBrickOrQuestionBlock(IMario mario, IBlock block)
        {
            if(block.ItemType != null)
            {
                block.Bumped();
                ObjectsManager.Instance.AddNonCollidableObject((IDynamic)Activator.CreateInstance(block.ItemType, block.Position));
            }else
            {
                block.Used();
                if (mario.HealthState is SmallMario)
                    ObjectsManager.Instance.AddNonCollidableObject((IDynamic)Activator.CreateInstance(typeof(RedMushroom), block.Position));
                else
                    ObjectsManager.Instance.AddNonCollidableObject((IDynamic)Activator.CreateInstance(typeof(Flower), block.Position));
            }
            if (block.ObjState == ObjectState.Destroy)           
                ObjectsManager.Instance.AddObject((IStatic)Activator.CreateInstance(typeof(UsedBlock), block.Position));

        }

        private void MarioVsHiddenBlock(IMario mario, IBlock block, Direction direction)
        {
            if (mario.Physics.Velocity.Y < 0 )
            {
                ResolveOverlap(mario, block, direction);
                GroundOrTopBounce(mario);
                block.Used();
                if (block.ItemType != null)
                    ObjectsManager.Instance.AddNonCollidableObject((IDynamic)Activator.CreateInstance(block.ItemType, block.Position));
                else
                {
                    if (mario.HealthState is SmallMario )
                        ObjectsManager.Instance.AddNonCollidableObject((IDynamic)Activator.CreateInstance(typeof(RedMushroom), block.Position));
                    else
                        ObjectsManager.Instance.AddNonCollidableObject((IDynamic)Activator.CreateInstance(typeof(Flower), block.Position));
                }
                ObjectsManager.Instance.AddObject((IStatic)Activator.CreateInstance(typeof(UsedBlock), block.Position));
            }
        }
        private static void GenerateDerbis()
        {
            ObjectsManager.Instance.AddNonCollidableObject(new BrickDerbis(location, BrickPosition.leftTop));
            ObjectsManager.Instance.AddNonCollidableObject(new BrickDerbis(location, BrickPosition.leftBottom));
            ObjectsManager.Instance.AddNonCollidableObject(new BrickDerbis(location, BrickPosition.rightTop));
            ObjectsManager.Instance.AddNonCollidableObject(new BrickDerbis(location, BrickPosition.rightBottom));
        }




        
    }
}
