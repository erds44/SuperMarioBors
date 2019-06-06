using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Blocks
{
    public interface IBlock : IObject
    {
        void ChangeState(IBlockState state);
        void ChangeSprite(ISprite sprite);
        void Used();
        void Disappear();
    }
}
