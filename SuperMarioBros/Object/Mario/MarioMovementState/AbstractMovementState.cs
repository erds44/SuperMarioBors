using Microsoft.Xna.Framework;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public abstract class AbstractMovementState : IMarioMovementState
    {
        protected private IMario mario;
        protected private Vector2 leftCrouchingOffset = new Vector2(-22, -22);
        protected private Vector2 rightNormalOffSet = new Vector2(52, -32);
        protected private Vector2 rightCrouchingOffset = new Vector2(52, -22);
        protected private Vector2 offset = new Vector2(-22, -32);
        protected private Vector2 slidingVelocity = new Vector2(0, 150);
        protected private FireBallDirection direction = FireBallDirection.left;
        protected static private int fireBallCount = 2;
        protected static private float fireBallCoolDown = 2f;
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
            mario.Physics.CurrentGravity = 100f;
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
