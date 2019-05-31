using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Command
{
    class RightCommand: ICommand
    {
        private readonly IReceiver action;
        public RightCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Right();
        }
    }
}
