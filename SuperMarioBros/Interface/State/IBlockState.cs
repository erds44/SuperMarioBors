namespace SuperMarioBros.Interface.State
{
    public interface IBlockState : IState
    {
        void ToUsed();
        void ToDisappear();
    }
}
