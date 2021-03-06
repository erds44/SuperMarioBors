﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Pipes
{
    public abstract class AbstractPipe : IPipe
    {
        private protected ISprite sprite;
        public Vector2 Position { get; set; }
        public Physics Physics { get; set; }
        public ObjectState ObjState { get; set; }
        public Vector2 TransferedLocation { get; protected set; }
        public Direction TeleportDirection { get; protected set; }
        public bool Teleported { get; set; }
        protected string PipeType { get; set; }
        public Rectangle HitBox
        {
            get
            {
                Point size = SpriteFactory.ObjectSize(PipeType);
                return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
            }
        }

        protected virtual void Initialize()
        {
            ObjState = ObjectState.Normal;
            sprite = SpriteFactory.CreateSprite(PipeType);
            sprite.SetLayer(Layers.PipeLayer);
            Physics = new Physics(Vector2.Zero, PhysicsConsts.ZeroGravity, PhysicsConsts.ZeroWeight);
            TransferedLocation = Vector2.Zero;
            TeleportDirection = Direction.none;
            Teleported = false;
        }

        public virtual void Destroy() { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public virtual void Update(GameTime gameTime) { }
    }
}
