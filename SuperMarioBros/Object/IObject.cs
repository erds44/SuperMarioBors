using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects
{
    public interface IObject : IDraw
    {
        Rectangle HitBox();
        Vector2 Position { get; set; }
    }
}
