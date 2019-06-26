using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Objects
{
    public interface IObject : IDraw
    {
        ObjectState ObjState { get; set; }
        Rectangle HitBox();
        Vector2 Position { get; set; }
        void Destroy();
        Physics Physics { get; set; }
    }
}
