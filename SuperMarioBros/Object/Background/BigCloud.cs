using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{

    public class BigCloud : AbstractBackground
    {
        public BigCloud(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
