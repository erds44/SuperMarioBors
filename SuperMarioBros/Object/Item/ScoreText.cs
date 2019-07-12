using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Physicses;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Items
{
    public class ScoreText : AbstractItem, IItem
    {
        private float timer = Timers.ScoreTextTimeSpan;
        private readonly SpriteFont spriteFont;
        private readonly string str;
        public ScoreText(Vector2 location, SpriteFont inputSpriteFont, string str)
        {
            Position = location;
            Physics = new Physics(PhysicsConsts.ScoreTextVelocity, itemGravity, itemWeight);
            ObjState = ObjectState.NonCollidable;
            spriteFont = inputSpriteFont;
            this.str = str;
        }

        public override void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Physics.Displacement(gameTime);
            if (timer <= 0)
                ObjState = ObjectState.Destroy;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, str, Position, Color.White, SpriteConsts.DefaultRotation, Vector2.Zero, SpriteConsts.DefaultScale, SpriteEffects.None, itemLayer);
        }
    }
}
