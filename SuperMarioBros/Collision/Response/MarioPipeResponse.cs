using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Marios;
using SuperMarioBros.Object.Pipes;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class MarioPipeResponse : GeneralResponse
    {
        private readonly IMario mario;
        private readonly IPipe pipe;
        private readonly Direction direction;
        private delegate void MarioBlockHandler(IMario mario, IPipe pipe, Direction direction);
        private static readonly Dictionary<Direction, Keys> keyDictionary = new Dictionary<Direction, Keys>
        {
            { Direction.top, Keys.Down},
            { Direction.left, Keys.Right},
            { Direction.bottom, Keys.Up},
            { Direction.right, Keys.Left},
        };
        private readonly Dictionary<Type, MarioBlockHandler> handlerDictionary = new Dictionary<Type, MarioBlockHandler>
        {
            {typeof(TeleportPipe), MarioVsTeleportPipe},
            {typeof(Pipe), MarioVsPipe},
        };
        public MarioPipeResponse(IObject mario, IObject pipe, Direction direction)
        {
            this.mario = (IMario)mario;
            this.pipe = (IPipe)pipe;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if (handlerDictionary.TryGetValue(pipe.GetType(), out var handler))
                handler(mario, pipe, direction);
        }

        private static void MarioVsPipe(IMario mario, IPipe pipe, Direction direction)
        {
            Rectangle overlap = Rectangle.Intersect(mario.HitBox(), pipe.HitBox());
            if (overlap == mario.HitBox() && !((Pipe)pipe).IsTeleporting)
            {
                mario.Teleport(new Vector2(6990, 332), Direction.top);
                ((Pipe)pipe).IsTeleporting = true;
                mario.SetPipeTeleportngEvent += ((Pipe)pipe).SetTeleporting;
            }
            if (!((Pipe)pipe).IsTeleporting)
            {
                MarioVsRegularPipe(mario, pipe, direction);
            }
        }

        private static void MarioVsTeleportPipe(IMario mario, IPipe pipe, Direction direction)
        {
            if (!pipe.Teleported)
            {
                keyDictionary.TryGetValue(direction, out Keys key);
                if (direction == pipe.TeleportDirection && Keyboard.GetState().IsKeyDown(key))
                {
                    pipe.Teleported = true;
                    mario.Teleport(pipe.TransferedLocation, ReverseDirection(direction));
                }
                else
                {
                    MarioVsRegularPipe(mario, pipe, direction);
                }
            }
        }
        private static void MarioOnGround(IMario mario)
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
            mario.Physics.Velocity = new Vector2(mario.Physics.Velocity.X, 0);
        }
        private static void MarioVsRegularPipe(IMario mario, IPipe pipe, Direction direction)
        {
            ResolveOverlap(mario, pipe, direction);
            switch (direction)
            {
                case Direction.top: MarioOnGround(mario); break;
                case Direction.bottom: GroundOrTopBounce(mario); break;
                default: LeftOrRightBlock(mario); break;
            }
        }
    }
}
