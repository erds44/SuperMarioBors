using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Command
{
    class QuestionToUsedCommand : ICommand
    {
        private readonly IReceiver action;
        public QuestionToUsedCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.QuestionBlockToUsedBlock();
        }
    }
}
