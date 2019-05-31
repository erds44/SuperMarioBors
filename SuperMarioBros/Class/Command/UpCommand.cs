using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Command
{
    class UpCommand : ICommand
    {
        private readonly IReceiver action;
        public UpCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Up();
        }
    }
}
