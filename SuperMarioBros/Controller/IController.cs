namespace SuperMarioBros.Controllers
{
    public interface IController : IUpdatable
    {
        void EnableController();
        void DisableController();
    }
}
