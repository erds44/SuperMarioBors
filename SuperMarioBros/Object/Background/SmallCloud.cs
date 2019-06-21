using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Backgrounds
{
    public class SmallCloud : AbstractBackground
    {
        public SmallCloud(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);

            sprite.SetLayer(0);
        }
    }
}
