using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects
{
    public interface IObject : IDraw
    {
        bool IsInvalid { get; set; }
        Rectangle HitBox();
        Vector2 Position { get; set; }
    }
}
