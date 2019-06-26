using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{

    public class SmallBush : AbstractBackground
    {
        public SmallBush(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
