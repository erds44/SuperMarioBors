using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Classes.Object.MarioObject
{
    public class FireMario :  IMarioState
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
            mario.ChangeMarioState(new BigMario(mario));
        }
    }
}
