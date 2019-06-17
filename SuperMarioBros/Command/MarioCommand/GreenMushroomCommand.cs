using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class GreenMushroomCommand : ICommand
    {
        private readonly IMario mario;
        public GreenMushroomCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.GreenMushroom();
        }
    }
}
