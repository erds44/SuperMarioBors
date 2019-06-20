using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using System;

namespace SuperMarioBros.Goombas
{
    public abstract class AbstractEnemy : IEnemy
    {
        public bool IsInvalid { get; set; }

        public IEnemyMovementState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        protected EnemyPhysics physics;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public abstract void Update(GameTime gameTime);

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }

        public void MoveUp()
        {
            physics.MoveUp();
        }

        public void MoveDown()
        {
            physics.MoveDown();
        }

        public abstract void MoveLeft();

        public abstract void MoveRight();

        public void Destroy()
        {
            //Game.Score += 100;
        }

        public abstract void TakeDamage();

        public abstract void Flip();

        public void BumpUp()
        {
            physics.BumpUp();
        }

    }
}
