namespace SuperMarioBros.Commands
{
    class PauseCommand : ICommand
    {
        private readonly MarioGame game;
        public PauseCommand(MarioGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Pause();
        }
    }
}
