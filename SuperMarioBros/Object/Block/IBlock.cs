using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Blocks
{
    public interface IBlock : IStatic
    {
        IBlockState State { get; set; }
        ISprite Sprite { get; set; }
        Type ItemType { get; }
        bool HasItem { get; set; }
        bool CanBeBumped { get; }
        void Used();
        void Bumped();
        void Broken();
       
    }
}
