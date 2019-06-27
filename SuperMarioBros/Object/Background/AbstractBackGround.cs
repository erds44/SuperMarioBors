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
        private protected ISprite sprite;
        public Vector2 Position { get; set; }
        public ObjectState ObjState { get; set; }
        public Physics Physics { get; set; }
        protected void Initialize()
        {
            ObjState = ObjectState.NonCollidable;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position,SpriteEffects.None, 0.6f);
        }

        public Rectangle HitBox()
        {
            return new Rectangle((int)Position.X,(int)Position.Y , 0, 0);
        }
        public void Destroy()
        {
            //Do nothing.
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
