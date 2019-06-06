using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class UpCommand : ICommand
    {
        private readonly IMario mario;
        public UpCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Up();
        }
    }
}
