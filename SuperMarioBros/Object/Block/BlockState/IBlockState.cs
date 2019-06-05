using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Blocks.BlockStates
{
    public interface IBlockState 
    {
        void ToUsed();
        void ToDisappear();
    }
}
