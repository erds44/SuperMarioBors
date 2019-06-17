using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class MoveMarioRightCommand : ICommand
    {
        private readonly IMario mario;
        public MoveMarioRightCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.MoveRight();
        }
    }
}
