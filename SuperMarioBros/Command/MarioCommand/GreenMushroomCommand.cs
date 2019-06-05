using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class GreenMushroomCommand : ICommand
    {
        private readonly IMario mario;
        public GreenMushroomCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.GreenMushroom();
        }
    }
}
