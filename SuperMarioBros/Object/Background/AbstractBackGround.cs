using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Backgrounds
{
    public abstract class AbstractBackground : IStatic
    {
        protected ISprite sprite;
        public Vector2 Position { get; set; }
        public ObjectState ObjState { get; set; }
        public Physics Physics { get; set; }
        public Rectangle HitBox { get => new Rectangle((int)Position.X, (int)Position.Y, 0, 0); }
        
        protected AbstractBackground(Vector2 location)
        {
            Position = location;
            ObjState = ObjectState.NonCollidable;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position,SpriteEffects.None, 1.5f);
        }

        public void Destroy() { }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
