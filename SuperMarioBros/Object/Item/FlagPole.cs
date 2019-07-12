using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Items
{
    public class FlagPole : AbstractItem, IItem
    {
        public FlagPole(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(Layers.FlagPoleLayer);
            Physics = new Physics(Vector2.Zero, PhysicsConsts.ZeroGravity, PhysicsConsts.ZeroWeight);
        }
        public override void Update(GameTime gameTime) { }
    }
}

