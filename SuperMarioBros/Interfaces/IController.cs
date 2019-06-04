namespace SuperMarioBros.Interfaces
{
    public interface IController
    {
        void Update();
        void Add(ICommand command);
    }
}
