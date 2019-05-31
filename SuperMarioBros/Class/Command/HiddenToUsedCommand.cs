using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Command
{
    class HiddenToUsedCommand : ICommand
    {
        private readonly IReceiver action;
        public HiddenToUsedCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.HiddenBlockToUsedBlock();
        }
    }
}
