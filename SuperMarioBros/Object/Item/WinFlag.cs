using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;
using System;
using System.Threading;


namespace SuperMarioBros.Items
{
    public class WinFlag : AbstractItem, IItem
    {
        public event EventHandler StartOverEvent;
        private readonly float speedChange;
        public WinFlag(Vector2 location)
        {
            Position = location;
            ObjState = ObjectState.NonCollidable;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(Layers.FlagLayer);
            Physics = new Physics(PhysicsConsts.WinFlagVelocity, PhysicsConsts.ZeroGravity,PhysicsConsts.ZeroWeight);
            speedChange = Position.Y - Locations.WinFlagOffset;
        }
        public override void Update(GameTime gameTime)
        {
            if (Position.Y >= speedChange)
                Position += Physics.Displacement(gameTime);
            else
            {
                Thread.Sleep(Timers.WinFlagSleepTime);
                StartOverEvent?.Invoke(this, new EventArgs());
            }
        }
        public override Rectangle ItemHitBox()
        {
            Point size = SpriteFactory.ObjectSize(GetType().Name);
            return new Rectangle((int)Position.X , (int)Position.Y - size.Y, size.X, size.Y);
        }
    }
}

