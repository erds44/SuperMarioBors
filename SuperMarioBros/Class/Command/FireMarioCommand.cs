using SuperMarioBros.Interface;

namespace SuperMarioBros
{
    class FireMarioCommand : ICommand
    {
        private readonly IReceiver action;
        public FireMarioCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.FireMario();
        }
    }
}
