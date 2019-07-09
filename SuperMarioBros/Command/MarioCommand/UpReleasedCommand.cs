using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class UpReleasedCommand : ICommand
    {
        private readonly IMario mario;
        public UpReleasedCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.Physics.JumpKeyUp = true;
        }
    }
}
