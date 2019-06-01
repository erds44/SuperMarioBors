namespace SuperMarioBros.Interfaces.States
{
    public interface IBlockState : IState
    {
        void ToUsed();
        void ToDisappear();
    }
}
