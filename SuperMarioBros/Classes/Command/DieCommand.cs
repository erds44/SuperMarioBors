
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Command
{
    class DieCommand : ICommand
    {
        private readonly IReceiver action;
        public DieCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public  void Execute()
        {
            action.DeadMario();
        }
    }
}
