using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class MoveMarioLeftCommand : ICommand
    {
        private readonly IMario mario;
        public MoveMarioLeftCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.MoveLeft();
        }
    }
}
