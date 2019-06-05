using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class CoinCommand : ICommand
    {
        private readonly IMario mario;
        public CoinCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Coin();
        }
    }
}
