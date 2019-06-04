using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros.Interfaces.Objects
{
    public interface IMushroom : IObject
    {
        void Collide(IMario mario);
    }
}
