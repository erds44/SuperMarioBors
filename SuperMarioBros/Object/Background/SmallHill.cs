using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{
    public class SmallHill : AbstractBackground
    {
        public SmallHill(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
