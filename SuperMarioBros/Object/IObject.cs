using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects
{
    public interface IObject : IDraw, IUpdate
    {
        Rectangle HitBox();
    }
}
