using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class PowerCommand : ICommand
    {
        private readonly IMario mario;
        public PowerCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.PowerFlag = true;
        }
    }
}
