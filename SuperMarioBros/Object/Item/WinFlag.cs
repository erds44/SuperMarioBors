using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Items
{
    public class WinFlag : AbstractItem, IItem
    {
        public event Action startOverEvent;
        private Vector2 flagVelocity = new Vector2(0, -14);
        private float flagHeight = 28f;
        private float speedChange;
        public WinFlag(Vector2 location)
        {
            Position = location;
            ObjState = ObjectState.NonCollidable;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0.39f);
            Physics = new Physics(flagVelocity, 0,0);
            speedChange = Position.Y - flagHeight;
        }
        public override void Update(GameTime gameTime)
        {
            if (Position.Y >= speedChange)
                Position += Physics.Displacement(gameTime);
            else
                startOverEvent?.Invoke();
        }
        public override Rectangle HitBox()
        {
            Point size = SpriteFactory.ObjectSize(GetType().Name);
            return new Rectangle((int)Position.X , (int)Position.Y - size.Y, size.X, size.Y);
        }
    }
}

