using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class DownCommand : ICommand
    {
        private readonly IMario mario;
        public DownCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Down();
        }
    }
}
