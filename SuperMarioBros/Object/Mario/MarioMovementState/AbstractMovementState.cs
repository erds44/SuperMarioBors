using Microsoft.Xna.Framework;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Object;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public abstract class AbstractMovementState
    {
        protected private IMario mario;
        protected private Vector2 leftNormalOffSet = new Vector2(-22, -32);
        protected private Vector2 leftCrouchingOffset = new Vector2(-22, -22);
        protected private Vector2 rightNormalOffSet = new Vector2(52, -32);
        protected private Vector2 rightCrouchingOffset = new Vector2(52, -22);
        protected private Vector2 offset = new Vector2(-22, -32);
        protected private fireBallDirection direction = fireBallDirection.left;
        protected private int fireBallCount = 2;
        protected private float fireBallCoolDown = 2f;
        protected private bool coolDown = false;
        public virtual void OnGround()
        {
            // Do Nothing
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
            else // For small and big Mario change speed when pressing x
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
    }
}
