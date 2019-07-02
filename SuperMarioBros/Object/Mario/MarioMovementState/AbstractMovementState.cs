using Microsoft.Xna.Framework;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public abstract class AbstractMovementState
    {
        protected private IMario mario;
        protected private Vector2 leftCrouchingOffset = new Vector2(-22, -22);
        protected private Vector2 rightNormalOffSet = new Vector2(52, -32);
        protected private Vector2 rightCrouchingOffset = new Vector2(52, -22);
        protected private Vector2 offset = new Vector2(-22, -32);
        protected private Vector2 slidingVelocity = new Vector2(0, 50);
        protected private FireBallDirection direction = FireBallDirection.left;
        protected private int fireBallCount = 2;
        protected private float fireBallCoolDown = 2f;
        protected private bool coolDown = false;
        public virtual void OnGround()
        {
            mario.OnGround = true;
        }
        public virtual void Update(GameTime gameTime)
        {
            if(mario.HealthState is FireMario)
            {
                if (coolDown)
                    fireBallCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (fireBallCoolDown <= 0)
                {
                    fireBallCoolDown = 2f;
                    coolDown = false;
                }
            }
            else if(mario.HealthState is BigMario && mario.OnGround) // For big Mario change speed when pressing x and on ground.
            {
                mario.Physics.SetSprintVelocityRate(mario.PowerFlag ? 1.2f : 1f);
            }
        }
        public virtual void OnFireBall()
        {
            if (!coolDown)
            {
                ObjectFactory.Instance.CreateFireBall(mario.Position + offset, direction);
                fireBallCount--;
                if (fireBallCount <= 0)
                {
                    coolDown = true;
                    fireBallCount = 2;
                }
            }
        }
        public virtual void SlidingFlagPole()
        {
            mario.MovementState = new LeftSliding(mario);
        }
        public virtual void ChangeSlidingDirection()
        {
            //Do Nothing
        }
    }
}
