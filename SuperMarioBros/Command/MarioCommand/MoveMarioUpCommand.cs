using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class MoveMarioUpCommand : ICommand
    {
        private readonly IMario mario;
        public MoveMarioUpCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.MoveUp();
        }
    }
}
