using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Managers;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public abstract class AbstractItem :IItem
    {
        private protected ISprite sprite;
        public Vector2 Position { get; set; }
        public Physics Physics { get; set; }
        public ObjectState ObjState { get; set; }

        protected bool addFlag;
        protected float speedChangeFlag;
        protected float peak = 45f;
        protected Vector2 initialVelocity = new Vector2(0, -180);
        protected Vector2 collidableVelocity = new Vector2(40, 0);
        protected float itemGravity =  800f;
        protected float itemWeight = 20f;
        //protected Vector2 offset = new Vector2(5, 0);
        protected float itemLayer = 1f;

        protected virtual void Initialize()
        {
            //Position += offset;
            ObjState = ObjectState.NonCollidable;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
            Physics = new Physics(initialVelocity, itemGravity, itemWeight);
            addFlag = false;
            speedChangeFlag += Position.Y - peak;
        }

        public virtual void Destroy()
        {
            // Do Nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
            //sprite.Draw(spriteBatch, Position,SpriteEffects.None, 0.8f);
        }

        public virtual Rectangle HitBox()
        {
            Point size = SizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update();
            Position += Physics.Displacement(gameTime);
            if (Position.Y <= speedChangeFlag && !addFlag)
            {
                Physics.Velocity = collidableVelocity;
                Physics.ApplyGravity();
                sprite.SetLayer(itemLayer);
                ObjState = ObjectState.Normal;
                addFlag = true;
            }
        }
    }
}
