using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Backgrounds
{
    public abstract class AbstractBackground : IStatic
    {
        protected ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public ObjectState ObjState { get; set; }
        public Physics Physics { get; set; }
        public Rectangle HitBox { get => new Rectangle((int)Position.X, (int)Position.Y, SpriteConsts.BackgroundWidth, SpriteConsts.BackgroundHeight); }
        
        protected AbstractBackground(Vector2 location)
        {
            Position = location;
            ObjState = ObjectState.NonCollidable;
            Sprite = SpriteFactory.CreateSprite(GetType().Name);
            Sprite.SetLayer(Layers.BackgroundLayer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position,SpriteEffects.None, SpriteConsts.BackgroundScale);
        }

        public void Destroy() { }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
