using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Managers;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class FireMario :  IMarioHealthState
    {
        private readonly IMario mario;
        public FireMario(IMario mario)
        {
            this.mario = mario;
            mario.Sprite = SpriteFactory.CreateSprite(GetType().Name + mario.MovementState.GetType().Name);
            mario.Physics.SetSprintVelocityRate(1);
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
            if (mario.PowerFlag)
                mario.MovementState.OnFireBall();
        }

        public void OnFireFlower()
        {
           // Do Nothing
        }
    }
}
