using SuperMarioBros.Classes.Object;

namespace SuperMarioBros.Interfaces.Object
{
    public interface IStar : IObject
    {
        void Collide(ObjectsManager objectsManager, IMario mario);
    }
}
