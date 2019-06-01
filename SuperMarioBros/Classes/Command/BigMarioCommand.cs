using SuperMarioBros.Interfaces;

namespace SuperMarioBros
{
    class BigMarioCommand : ICommand
    {
        private readonly IReceiver action;
        public BigMarioCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.BigMario();
        }
    }
}
