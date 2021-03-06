﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Managers;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using SuperMarioBros.Utility;
using System;

namespace SuperMarioBros.Blocks
{

    public abstract class AbstractBlock : IBlock
    {
        public IBlockState State { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public Physics Physics { get; set; }
        public Type ItemType { get; protected set; }
        public bool HasItem { get; set; }
        public ObjectState ObjState { get; set; }
        public int BumpedCount { get; set; }
        public bool CanBeBumped { get; protected set; }
        public Rectangle HitBox
        {
            get
            {
                Point size = SpriteFactory.ObjectSize(GetType().Name);
                return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
            }
        } 
        public void Initialize()
        {
            ObjState = ObjectState.Normal;
            State = new NormalState(this);
            Physics = new Physics(Vector2.Zero, PhysicsConsts.ZeroGravity, PhysicsConsts.ZeroWeight);
            Sprite?.SetLayer(Layers.BlockLayer);
        }
        public virtual void Destroy() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite?.Draw(spriteBatch, Position);
        }

        public virtual void Used()
        {
            State.Used();
        }
        public virtual void Bumped()
        {
            State.Bumped();
        }

        public virtual void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            Sprite?.Update(gameTime);
        }

        public virtual void Broken() { }

    }
}
