using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class LeftCommand : ICommand
    {
        private readonly IMario mario;
        public LeftCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Left();
        }
    }
}
