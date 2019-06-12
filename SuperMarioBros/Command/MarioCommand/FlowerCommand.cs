using SuperMarioBros.Marios;

namespace SuperMarioBros.Commands
{
    class FlowerCommand : ICommand
    {
        private readonly IMario mario;
        public FlowerCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.OnFireFlower();
        }
    }
}
