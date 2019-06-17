using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class IdleCommand : ICommand
    {
        private readonly IMario mario;
        public IdleCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.Idle();
        }
    }
}
