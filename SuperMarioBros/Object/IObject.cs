using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Objects
{
    public interface IObject : IDraw, IUpdate
    {
        Rectangle HitBox();
    }
}
