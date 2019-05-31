using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Interface.Object.BlockObject
{
    public interface IBlockObject : IObject
    {
        void ChangeState(IBlockState state);
        void Used();
        void Disappear();
    }
}
