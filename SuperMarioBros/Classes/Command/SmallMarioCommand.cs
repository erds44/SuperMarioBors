using SuperMarioBros.Interfaces;

namespace SuperMarioBros
{
    class SmallMarioCommand : ICommand
    {
        private readonly IReceiver action;
        public SmallMarioCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.SmallMario();
        }
    }
}
