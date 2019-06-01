using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Command
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
