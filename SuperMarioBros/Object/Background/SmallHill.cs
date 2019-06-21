using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{
    public class SmallHill : AbstractBackground
    {
        public SmallHill(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
        }
    }
}
