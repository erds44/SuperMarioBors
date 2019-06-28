using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public interface IHandler
    {
        void HandleCollision(IObject obj1, IObject obj2, Direction direction);
    }
}
