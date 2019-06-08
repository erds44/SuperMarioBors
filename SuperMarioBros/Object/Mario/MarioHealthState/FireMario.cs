using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class FireMario :  IMarioHealthState
    {
        private readonly IMario mario;
        public FireMario(IMario mario)
        {
            this.mario = mario;
        }
        public void FireFlower()
        {
            // Do Nothing
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
            mario.ChangHealthState(new BigMario(mario));
        }
    }
}
