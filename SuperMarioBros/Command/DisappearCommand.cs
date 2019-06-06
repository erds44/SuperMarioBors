using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    public class DisappearCommand : ICommand
    {
        private readonly IObject gameObject;
        private readonly int index;
        public DisappearCommand(IObject gameObject, int index)
        {
            this.gameObject = gameObject;
            this.index = index;
        }
        public void Execute()
        {
            ObjectsManager.Instance.Remove(gameObject, index);
        }
    }
}
