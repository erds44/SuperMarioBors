using SuperMarioBros.Marios;

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
        }
    }
}
