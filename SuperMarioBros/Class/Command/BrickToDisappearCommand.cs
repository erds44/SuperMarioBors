using SuperMarioBros.Interface;


namespace SuperMarioBros.Class.Command
{
    class BrickToDisappearCommand : ICommand
    {
        private readonly IReceiver action;
        public BrickToDisappearCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.BrickBlockDisappear();
        }
    }
}
