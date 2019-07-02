using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class FlagPole : AbstractItem, IItem
    {
        public FlagPole(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0.4f);
            Physics = new Physics(Vector2.Zero, 0, 0);
        }
        public override void Update(GameTime gameTime)
        {
            // Do Nothing
        }
    }
}

