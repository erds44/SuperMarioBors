using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Command
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
