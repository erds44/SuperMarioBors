using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Blocks
{
    public interface IBlock : IObject
    {
        IBlockState state { get; }
        Point location { get; }
        void Used();
        void ChangeSprite(ISprite sprite);
        void ChangeState(IBlockState blockState);
    }
}
