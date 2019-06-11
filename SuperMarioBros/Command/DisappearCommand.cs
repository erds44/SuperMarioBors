using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    public class DisappearCommand : ICommand
    {
        private readonly IObject gameObject;
        public DisappearCommand(IObject gameObject)
        {
            this.gameObject = gameObject;
        }
        public void Execute()
        {
            ObjectsManager.Instance.Remove(gameObject);
        }
    }
}
