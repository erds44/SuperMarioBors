using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Command
{
    class LeftCommand : ICommand
    {
        private readonly IReceiver action;
        public LeftCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Left();
        }
    }
}
