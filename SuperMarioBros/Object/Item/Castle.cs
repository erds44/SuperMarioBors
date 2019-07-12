using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Items
{
    public class Castle : AbstractItem, IItem
    {
        public Castle(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(Layers.CastleLayer);
            Physics = new Physics(Vector2.Zero, PhysicsConsts.ZeroGravity, PhysicsConsts.ZeroWeight);
        }
        public override void Update(GameTime gameTime) { }

        public override Rectangle ItemHitBox()
        {
            Point size = SpriteFactory.ObjectSize(GetType().Name);
            return new Rectangle((int)(Position.X + Locations.CastleOffset), (int)Position.Y - size.Y, size.X, size.Y);
        }
    }
}

