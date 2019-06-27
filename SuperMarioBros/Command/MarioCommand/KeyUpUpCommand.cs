using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class KeyUpUpCommand : ICommand
    {
        private readonly IMario mario;
        public KeyUpUpCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.Physics.JumpKeyUp = true;
        }
    }
}
