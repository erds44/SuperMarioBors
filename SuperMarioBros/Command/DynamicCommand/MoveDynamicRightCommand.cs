using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class MoveDynamicRightCommand : ICommand
    {
        private readonly IDynamic dynamic;
        public MoveDynamicRightCommand(IDynamic dynamic)
        {
            this.dynamic = dynamic;
        }
        public void Execute()
        {
            dynamic.MoveRight();
        }
    }
}
