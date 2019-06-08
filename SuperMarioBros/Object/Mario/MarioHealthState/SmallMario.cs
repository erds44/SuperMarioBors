using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class SmallMario : IMarioHealthState
    {
        private readonly IMario mario;

        public SmallMario(IMario mario)
        {
            this.mario = mario;
        }

        public void TakeDamage()
        {
            mario.ChangHealthState(new DeadMario());
        }

        public void RedMushroom()
        {
            mario.ChangHealthState(new BigMario(mario));
        }

        public void FireFlower()
        {
            mario.ChangHealthState(new FireMario(mario));
        }

        public void GreenMushroom()
        {
            //Do Nothing
        }
    }
}
