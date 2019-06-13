using SuperMarioBros.Commands;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Controllers
{
    public interface IController : IUpdate
    {
        void SetIdle(ICommand idleCommand);
    }
}
