using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Castle : AbstractItem, IItem
    {
        private readonly float castleOffset = 94f;
        public Castle(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0.4f);
            Physics = new Physics(Vector2.Zero, 0, 0);
        }
        public override void Update(GameTime gameTime) { }

        public override Rectangle ItemHitBox()
        {
            Point size = SpriteFactory.ObjectSize(GetType().Name);
            return new Rectangle((int)(Position.X + castleOffset), (int)Position.Y - size.Y, size.X, size.Y);
        }
    }
}

