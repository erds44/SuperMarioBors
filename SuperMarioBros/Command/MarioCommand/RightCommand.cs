using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class RightCommand: ICommand
    {
        private readonly IMario mario;
        public RightCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Right();
        }
    }
}
