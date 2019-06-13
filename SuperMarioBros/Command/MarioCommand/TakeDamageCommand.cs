using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class TakeDamageCommand : ICommand
    {
        private readonly IMario mario;
        public TakeDamageCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.TakeDamage();
            /* Add feature for invisible Mario when taking dmg 
               It might not be the correct place to do so
               we might change later
            */
            ObjectsManager.Instance.DecorateMario(mario, new FlashingMario(mario));
        }
    }
}
