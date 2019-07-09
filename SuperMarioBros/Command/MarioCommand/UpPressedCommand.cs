using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class UpPressedCommand : ICommand
    {
        private readonly IMario mario;
        public UpPressedCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.MoveUp();
        }
    }
}
