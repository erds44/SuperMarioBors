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
            //mario.Sprite = SpriteFactory.CreateSprite(GetType().Name + "RightIdle");
        }

        public void TakeDamage()
        {
            mario.HealthState = new SmallMario(mario);
        }

        public void Update(GameTime gameTime)
        {
            // Do Nothing
        }

        public void TakeRedMushroom()
        {
            // Do Nothing
        }

        public void OnFireFlower()
        {
            mario.HealthState = new FireMario(mario);
        }
    }
}
