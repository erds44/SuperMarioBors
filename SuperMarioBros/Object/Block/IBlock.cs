using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.Blocks
{
    public interface IBlock : IObject
    {
        void Used();
        Type GetRealType();
    }
}
