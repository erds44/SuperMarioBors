using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class CoinCommand : ICommand
    {
        private readonly IMario mario;
        public CoinCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.Coin();
        }
    }
}
