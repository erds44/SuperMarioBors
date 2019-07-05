using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Object.Pipes
{
    public interface IPipe : IStatic
    {
        Vector2 TransferedLocation { get; }
        Direction TeleportDirection { get; }
        bool Teleported { get; set; }
    }
}
