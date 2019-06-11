using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class TakeDamageCommand : ICommand
    {
        private readonly IMario mario;
        private readonly int index;
        public TakeDamageCommand(IMario mario, int index)
        {
            this.mario = mario;
            this.index = index;
        }
        public void Execute()
        {
            mario.TakeDamage();
            if (!(mario.HealthState is DeadMario))
            {
                ObjectsManager.Instance.DecorateMario(new FlashingMario(mario, index), index);
            }
        }
    }
}
