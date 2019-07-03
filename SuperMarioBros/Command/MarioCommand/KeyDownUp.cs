using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class KeyDownUpCommand : ICommand
    {
        private readonly IMario mario;
        public KeyDownUpCommand(IDynamic mario)
        {
            this.mario =(IMario) mario;
        }
        public void Execute()
        {
            mario.KeyDownUp();
        }
    }
}
