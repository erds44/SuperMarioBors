using SuperMarioBros.Interfaces;

namespace SuperMarioBros
{
    class MarioIdleCommand : ICommand
    {
        private readonly IReceiver action;
        public MarioIdleCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Idle();
        }
    }
}
