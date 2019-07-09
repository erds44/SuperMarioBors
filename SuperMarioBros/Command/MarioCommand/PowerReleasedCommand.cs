using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class PowerReleasedCommand : ICommand
    {
        private readonly IMario mario;
        public PowerReleasedCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.PowerReleased();
        }
    }
}
