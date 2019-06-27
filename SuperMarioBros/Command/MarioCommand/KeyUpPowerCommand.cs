using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class KeyUpPowerCommand : ICommand
    {
        private readonly IMario mario;
        public KeyUpPowerCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.KeyUpPower = true;
        }
    }
}
