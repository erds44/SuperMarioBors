using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class IdleCommand : ICommand
    {
        private readonly IMario mario;
        public IdleCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Idle();
        }
    }
}
