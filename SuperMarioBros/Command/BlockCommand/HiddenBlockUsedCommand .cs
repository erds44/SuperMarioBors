using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class HiddenBlockUsedCommand : ICommand
    {
        private readonly IBlock block;
        public HiddenBlockUsedCommand(IStatic block)
        {
            this.block = (IBlock)block;
        }
        public void Execute()
        {
            ObjectsManager.Instance.HiddenUsed(block);
        }
    }
}
