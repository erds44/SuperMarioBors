using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class MoveDynamicDownCommand : ICommand
    {
        private readonly IDynamic dynamic;
        public MoveDynamicDownCommand(IDynamic dynamic)
        {
            this.dynamic = dynamic;
        }
        public void Execute()
        {
            dynamic.MoveDown();
        }
    }
}
