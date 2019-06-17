using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class MoveDynamicUpCommand : ICommand
    {
        private readonly IDynamic dynamic;
        public MoveDynamicUpCommand(IDynamic dynamic)
        {
            this.dynamic = dynamic;
        }
        public void Execute()
        {
            dynamic.MoveUp();
        }
    }
}
