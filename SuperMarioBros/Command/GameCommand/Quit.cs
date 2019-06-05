namespace SuperMarioBros.Commands
{
    class Quit : ICommand
    {
        private readonly MarioGame game;
        public Quit(MarioGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Exit();
        }
    }
}
