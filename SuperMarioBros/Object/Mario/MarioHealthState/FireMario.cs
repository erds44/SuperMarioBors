using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class FireMario :  IMarioHealthState
    {
        private readonly IMario mario;
        private static int fireBallCount = GeneralConstants.FireBallCount;
        private static float fireBallCoolDown = Timers.FireBallCoolDown;
        private static bool isCoolDown = false;
        public FireMario(IMario mario)
        {
            this.mario = mario;
            mario.Sprite = SpriteFactory.CreateSprite(GetType().Name + mario.MovementState.GetType().Name);
            mario.Physics.SetSprintVelocityRate(PhysicsConsts.DefaultSprintVelocityRate);
        }

        public void TakeDamage()
        {
            mario.HealthState = new SmallMario(mario);
        }

        public void TakeRedMushroom()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            if (isCoolDown)
                fireBallCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(fireBallCoolDown <= 0)
            {
                fireBallCoolDown = Timers.FireBallCoolDown;
                isCoolDown = false;
            }
        }

        public void TakeFireFlower()
        {
           // Do Nothing
        }

        public void PowerPressed()
        {
            if (!isCoolDown)
            {
                mario.MovementState.OnFireBall();
                fireBallCount--;
                if (fireBallCount <= 0)
                {
                    isCoolDown = true;
                    fireBallCount = GeneralConstants.FireBallCount;
                }
            }
        }

        public void PowerReleased()
        {

        }
    }
}
