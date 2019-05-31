using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Command
{
    class DownCommand : ICommand
    {
        private readonly IReceiver action;
        public DownCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Down();
        }
    }
}
