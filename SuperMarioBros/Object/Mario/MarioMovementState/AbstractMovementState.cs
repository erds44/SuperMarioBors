using Microsoft.Xna.Framework;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public abstract class AbstractMovementState : IMarioMovementState
    {
        protected private IMario mario;
        protected private Vector2 leftCrouchingOffset = Locations.MarioLeftCrouchingOffset;
        protected private Vector2 rightNormalOffSet = Locations.MarioRightNormalOffSet;
        protected private Vector2 rightCrouchingOffset = Locations.MarioRightCrouchingOffset;
        protected private Vector2 offset = Locations.MarioOffset;
        protected private Vector2 slidingVelocity = PhysicsConsts.SlidingMarioVelocity;
        protected private FireBallDirection direction = FireBallDirection.left;
        protected static private int fireBallCount = GeneralConstants.FireBallCount;
        protected static private float fireBallCoolDown = Timers.FireBallCoolDown;
        protected static private bool coolDown = false;
        public virtual void OnGround()
        {
            mario.OnGround = true;
        }
        public virtual void Update(GameTime gameTime) { }

        public virtual void OnFireBall()
        {
            ObjectFactory.Instance.CreateFireBall(mario.Position + offset, direction);
        }
        public virtual void SlidingFlagPole()
        {
            mario.Physics.CurrentGravity = PhysicsConsts.SlidingMarioGravity;
            mario.MovementState = new LeftSliding(mario);
        }
        public virtual void ChangeSlidingDirection() { }

        public virtual void Left() { }

        public virtual void Down() { }

        public virtual void Up() { }

        public virtual void Right() { }

        public virtual void Idle() { }
    }
}
