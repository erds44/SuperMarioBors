using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public interface ICollisionResponder
    {
        void HandleCollision(IObject mover, IObject target, Direction direction);
    }
}
