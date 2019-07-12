using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Items
{
    public abstract class AbstractItem :IItem
    {
        private protected ISprite sprite;
        public Vector2 Position { get; set; }
        public Physics Physics { get; set; }
        public ObjectState ObjState { get; set; }
        public Rectangle HitBox { get => ItemHitBox(); }
        private protected bool addFlag;
        private protected float speedChangeFlag;
        private protected float peak = PhysicsConsts.ItemPeak;
        private protected Vector2 initialVelocity = PhysicsConsts.ItemInitialVelocity;
        private protected Vector2 collidableVelocity = PhysicsConsts.ItemCollidableVelocity;
        private protected float itemGravity =  PhysicsConsts.ItemGravity;
        private protected float itemWeight = PhysicsConsts.ItemWeight;
        private protected float itemLayer = Layers.ItemLayer;


        protected virtual void Initialize()
        {
            ObjState = ObjectState.NonCollidable;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(Layers.ItemInitialLayer);
            Physics = new Physics(initialVelocity, itemGravity, itemWeight);
            addFlag = false;
            speedChangeFlag += Position.Y - peak;
        }

        public virtual void Destroy() { }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public virtual Rectangle ItemHitBox()
        {
            Point size = SpriteFactory.ObjectSize(GetType().Name);
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
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
