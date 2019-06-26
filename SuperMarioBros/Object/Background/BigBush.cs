using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{

    public class BigBush : AbstractBackground
    {
        public BigBush(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
