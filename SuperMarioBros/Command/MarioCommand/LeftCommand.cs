using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class LeftCommand : ICommand
    {
        private readonly IMario mario;
        public LeftCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.Left();
        }
    }
}
