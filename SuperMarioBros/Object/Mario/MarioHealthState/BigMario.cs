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

        public void Coin()
        {
            // To do
        }

        public void OnFireFlower()
        {
            mario.HealthState = new FireMario(mario);
        }

        public void GreenMushroom()
        {
            // Do Nothing
        }

        public void RedMushroom()
        {
            // Do Nothing
        }

        public void TakeDamage()
        {
            mario.HealthState = new SmallMario(mario);
        }
    }
}
