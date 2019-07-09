using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class BigMario : IMarioHealthState
    {
        private readonly IMario mario;
        public BigMario(IMario mario)
        {
            this.mario = mario;
            mario.Sprite = SpriteFactory.CreateSprite(GetType().Name + mario.MovementState.GetType().Name);
        }

        public void TakeDamage()
        {
            mario.HealthState = new SmallMario(mario);
        }

        public void Update(GameTime gameTime) { }

        public void TakeRedMushroom() { }

        public void TakeFireFlower()
        {
            mario.HealthState = new FireMario(mario);
        }

        public void PowerPressed()
        {
            if (mario.OnGround)
                mario.Physics.SetSprintVelocityRate(1.2f);
        }

        public void PowerReleased()
        {
            if (mario.OnGround)
                mario.Physics.SetSprintVelocityRate(1f);
        }
    }
}
