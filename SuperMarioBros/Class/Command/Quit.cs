using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Command
{
    class Quit : ICommand
    {
        private readonly IReceiver action;
        public Quit(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Quit();
        }
    }
}
