using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Items
{
    public class Star : AbstractItem, IItem
    {
        private Vector2 starInitialVelocity = new Vector2(40, -140);
        private float starGravity = 200f;
        public Star(Vector2 location)
        {
            Position = location;
            collidableVelocity = starInitialVelocity;
            itemGravity = starGravity;
            base.Initialize();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position, SpriteEffects.None, 0.8f);
        }
    }
}

