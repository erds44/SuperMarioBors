using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class MoveMarioDownCommand : ICommand
    {
        private readonly IMario mario;
        public MoveMarioDownCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.MoveDown();
        }
    }
}
