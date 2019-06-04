using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Classes.Object.MarioObject
{
    public class SmallMario : IMarioState
    {
        private readonly IMario mario;
        public SmallMario(IMario mario)
        {
            this.mario = mario;
        }

        public void TakeDamage()
        {
            mario.ChangeMarioState(new DeadMario());
        }

        public void RedMushroom()
        {
            mario.ChangeMarioState(new BigMario(mario));
        }

        public void FireFlower()
        {
            mario.ChangeMarioState(new FireMario(mario));
        }

        public void GreenMushroom()
        {
            //Do Nothing
        }
    }
}
