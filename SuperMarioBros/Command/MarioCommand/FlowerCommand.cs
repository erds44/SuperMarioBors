using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class FlowerCommand : ICommand
    {
        private readonly IMario mario;
        public FlowerCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.OnFireFlower();
        }
    }
}
