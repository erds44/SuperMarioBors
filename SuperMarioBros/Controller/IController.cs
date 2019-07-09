namespace SuperMarioBros.Controllers
{
    public interface IController : IUpdatable
    {
        bool IsPause { get; set; }
    }
}
