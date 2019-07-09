using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class DownCommand : ICommand
    {
        private readonly IMario mario;
        public DownCommand(IDynamic mario)
        {
            this.mario =(IMario) mario;
        }
        public void Execute()
        {
            mario.MoveDown();
        }
    }
}
