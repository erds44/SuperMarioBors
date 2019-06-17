using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class RedMushroomCommand : ICommand
    {
        private readonly IMario mario;
        public RedMushroomCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.RedMushroom();
        }
    }
}
