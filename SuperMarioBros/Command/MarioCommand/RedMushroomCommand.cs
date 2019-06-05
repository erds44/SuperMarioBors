using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class RedMushroomCommand : ICommand
    {
        private readonly IMario mario;
        public RedMushroomCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.RedMushroom();
        }
    }
}
