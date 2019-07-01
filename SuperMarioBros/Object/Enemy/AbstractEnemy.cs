using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Objects.Enemy
{
    public abstract class AbstractEnemy : IEnemy
    {
        public event Action<Vector2, int> StompedEvent;
        public IEnemyMovementState MovementState { get; set; }
        public IEnemyHealthState HealthState { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Physics Physics { get; set; }
        public ObjectState ObjState { get; set; }
        private protected bool IsFlipped;
        private protected Vector2 initialVelocity = new Vector2(-30, 0);
        private protected float enemyGravity = 800f;
        private protected float enemyWeight = 200f;

        protected void Initialize()
        {
            ObjState = ObjectState.Normal;
            Physics = new Physics(Vector2.Zero, enemyGravity, enemyWeight);
            Physics.ApplyGravity();
            IsFlipped = false;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsFlipped)
                ((UniversalSprite)Sprite).Draw(spriteBatch, Position, SpriteEffects.FlipVertically);
            else
                Sprite.Draw(spriteBatch, Position);
        }
        public virtual Rectangle HitBox()
        {
            Point size = SpriteFactory.ObjectSize(MovementState.GetType().Name);
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }
        public void Destroy()
        {
            //Do Nothing For Now
        }
        public virtual void Update(GameTime gameTime)
        {
            Position += Physics.Displacement(gameTime);
            Sprite.Update(gameTime);
        }
        public virtual void ChangeDirection()
        {
            MovementState.ChangeDirection();
        }
        public virtual void Stomped(int count)
        {
            StompedEvent?.Invoke(Position, count);
        }

        public virtual void Flipped(int count)
        {
            IsFlipped = true;
            StompedEvent?.Invoke(Position, count);
        }

        public void MoveLeft()
        {
            MovementState.MoveLeft();
        }

        public void MoveRight()
        {
            MovementState.MoveRight();
        }
    }
}
