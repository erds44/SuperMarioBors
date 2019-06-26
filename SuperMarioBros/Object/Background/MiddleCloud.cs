using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{
    public class MiddleCloud : AbstractBackground
    {
        public MiddleCloud(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
