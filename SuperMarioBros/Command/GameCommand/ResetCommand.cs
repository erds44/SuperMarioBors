namespace SuperMarioBros.Commands
{
    class ResetCommand : ICommand
    {
        private readonly MarioGame game;
        public ResetCommand(MarioGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.ResetGame();
        }
    }
}
