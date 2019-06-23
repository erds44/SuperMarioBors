using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects
{
    public interface IObject : IDraw
    {
        ObjectState ObjState { get; set; }
        Rectangle HitBox();
        Vector2 Position { get; set; }
        void Destroy();
    }
}
