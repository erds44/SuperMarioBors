using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    public class BrickDisappearCommand : ICommand
    {
        private readonly IBlock block;
        public BrickDisappearCommand(IStatic block)
        {
            this.block = (IBlock)block;
        }
        public void Execute()
        {
            ObjectsManager.Instance.BrickDisappear(block);
        }
    }
}
