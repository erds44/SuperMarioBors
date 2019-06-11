using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    public class BrickDisappearCommand : ICommand
    {
        private readonly IBlock block;
        public BrickDisappearCommand(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            ObjectsManager.Instance.BrickDisappear(block);
        }
    }
}
