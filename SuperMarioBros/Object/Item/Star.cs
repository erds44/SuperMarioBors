using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Items
{
    public class Star : AbstractItem, IItem
    {
        public Star(Vector2 location)
        {
            Position = location;
            collidableVelocity = PhysicsConsts.StarInitialVelocity;
            itemGravity = PhysicsConsts.StarGravity;
            base.Initialize();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position, SpriteEffects.None, SpriteConsts.StarScale);
        }
    }
}

