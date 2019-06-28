﻿using Microsoft.Xna.Framework;
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

        private protected bool addFlag;
        private protected float speedChangeFlag;
        private protected float peak = 45f;
        private protected Vector2 initialVelocity = new Vector2(0, -180);
        private protected Vector2 collidableVelocity = new Vector2(40, 0);
        private protected float itemGravity =  800f;
        private protected float itemWeight = 20f;
        private protected float itemLayer = 1f;

        protected virtual void Initialize()
        {
            ObjState = ObjectState.NonCollidable;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0.4f);
            Physics = new Physics(initialVelocity, itemGravity, itemWeight);
            addFlag = false;
            speedChangeFlag += Position.Y - peak;
        }

        public virtual void Destroy()
        {
            // Do Nothing
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public virtual Rectangle HitBox()
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
