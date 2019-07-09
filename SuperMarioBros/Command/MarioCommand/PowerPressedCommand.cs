using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class PowerPressedCommand : ICommand
    {
        private readonly IMario mario;
        public PowerPressedCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.PowerPressed();
        }
    }
}
