using Microsoft.Xna.Framework;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Pipes;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Collisions
{
    public class MarioPipeCollisionHandler : GeneralHandler
    {
        public static void MarioVsRegularPipeTopOrBottomCollision(IMario mario, IPipe target, Direction direction)
        {
            if(!MarioInPipe(mario, target, direction))
            {
                MarioOnGround(mario, target, direction);
            }
        }
        public static void MarioVsRegularPipeLeftOrRightCollision(IMario mario, IPipe target, Direction direction)
        {
            if (!MarioInPipe(mario, target, direction))
            {
                MoverHorizontallyBlock(mario, target, direction);
            }
            
        }
        public static void MarioVsTeleportPipeTopCollision(IMario mario, IPipe pipe, Direction direction)
        {
            bool isCrounching = (mario.MovementState is LeftCrouching || mario.MovementState is RightCrouching);
            if (direction == pipe.TeleportDirection && isCrounching && MarioInTopSidePipeRange(mario,pipe))
            {
                pipe.Teleported = true;
                mario.Teleport(pipe.TransferedLocation, ReverseDirection(direction));
            }
            else
                MarioOnGround(mario, pipe, direction);
        }

        public static void MarioVsTeleportPipeLeftCollision(IMario mario, IPipe pipe, Direction direction)
        {
            if (!(pipe.Teleported))
            {
                bool isMoving = mario.MovementState is RightMoving;
                if (direction == pipe.TeleportDirection && isMoving && MarioInHorizontalSidePipeRange(mario, pipe))
                {
                    pipe.Teleported = true;
                    mario.Teleport(pipe.TransferedLocation, ReverseDirection(direction));
                }
                else
                    MoverHorizontallyBlock(mario, pipe, direction);
            }
        }

        public static void MarioVsTeleportPipeRightCollision(IMario mario, IPipe pipe, Direction direction)
        {
            if (!(pipe.Teleported))
            {
                bool isMoving = mario.MovementState is LeftMoving;
                if (direction == pipe.TeleportDirection && isMoving && MarioInHorizontalSidePipeRange(mario, pipe))
                {
                    pipe.Teleported = true;
                    mario.Teleport(pipe.TransferedLocation, ReverseDirection(direction));
                }
                else
                    MoverHorizontallyBlock(mario, pipe, direction);
            }
        }

        private static bool MarioInPipe(IMario mario, IPipe pipe, Direction direction)
        {
            Rectangle overlap = Rectangle.Intersect(mario.HitBox, pipe.HitBox);
            if (overlap == mario.HitBox)
            {
                mario.Teleport(Vector2.Zero, Direction.top);
                return true;
            }
            return false;
        }
        private static bool MarioInTopSidePipeRange(IMario mario, IPipe pipe)
        {
            Rectangle overlap = Rectangle.Intersect(mario.HitBox, pipe.HitBox);
            if (overlap.Width == mario.HitBox.Width)
                return true;
            return false;
        }
        private static bool MarioInHorizontalSidePipeRange(IMario mario, IPipe pipe)
        {
            Rectangle overlap = Rectangle.Intersect(mario.HitBox, pipe.HitBox);
            if (overlap.Height == mario.HitBox.Height)
                return true;
            return false;
        }
        private static void MarioOnGround(IMario mario, IPipe pipe, Direction direction)
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
            mario.Physics.Velocity = new Vector2(mario.Physics.Velocity.X, PhysicsConsts.ZeroVelocity); //Halt vertical movement.
            ResolveOverlap(mario, pipe, direction);
        }
    }
}
