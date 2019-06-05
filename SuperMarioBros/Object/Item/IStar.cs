using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Items
{
    public interface IStar : IObject
    {
        void Collide(ObjectsManager objectsManager, IMario mario);
    }
}
