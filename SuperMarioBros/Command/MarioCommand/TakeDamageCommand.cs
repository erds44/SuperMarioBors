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
            ObjectsManager.Instance.DecorateMario(mario, new FlashingMario(mario));
        }
    }
}
