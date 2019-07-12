using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Objects
{
    public interface IObject : IDrawable, IUpdatable
    {
        ObjectState ObjState { get; set; }
        Rectangle HitBox { get; }
        Vector2 Position { get; set; }
        void Destroy();
        Physics Physics { get; set; }
    }
}
