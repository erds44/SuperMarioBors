using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class MoveDynamicLeftCommand : ICommand
    {
        private readonly IDynamic dynamic;
        public MoveDynamicLeftCommand(IDynamic dynamic)
        {
            this.dynamic = dynamic;
        }
        public void Execute()
        {
            dynamic.MoveLeft();
        }
    }
}
