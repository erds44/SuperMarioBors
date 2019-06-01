using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Interfaces.Objects.BlockObjects
{
    public interface IBlockObject : IObject
    {
        void ChangeState(IBlockState state);
        void Used();
        void Disappear();
    }
}
