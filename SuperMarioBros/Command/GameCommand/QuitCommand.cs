namespace SuperMarioBros.Commands
{
    class QuitCommand : ICommand
    {
        private readonly MarioGame game;
        public QuitCommand(MarioGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Exit();
        }
    }
}
