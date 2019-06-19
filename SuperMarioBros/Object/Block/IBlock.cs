using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Blocks
{
    public interface IBlock : IStatic
    {
        IBlockState State { get; }
        void Used();
        void Bump();
        void ChangeSprite(ISprite sprite);
        void ChangeState(IBlockState blockState);
    }
}
