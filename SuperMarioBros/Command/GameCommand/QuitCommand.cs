namespace SuperMarioBros.Commands
{
    class QuitCommand : ICommand
    {
        public void Execute()
        {
            MarioGame.Instance.Exit();
        }
    }
}
