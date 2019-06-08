using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class DeadMario : IMarioHealthState
    {
        public DeadMario(IMario mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite(nameof(DeadMario));
            mario.MovementState = new TerminateMovementState();
        }

        public void Coin()
        {
            // To Do
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
            // Do Nothing
        }

    }
}
