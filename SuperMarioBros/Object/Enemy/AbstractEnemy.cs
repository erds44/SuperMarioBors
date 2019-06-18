using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Goombas
{
    public abstract class AbstractEnemy : IEnemy
    {
        public bool IsInvalid { get; set; }

        public IEnemyMovementState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        protected EnemyPhysics physics;

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update();
            Position += physics.Displacement(gameTime);
        }

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

        public void MoveLeft()
        {
            State.ChangeDirection();
            physics.MoveLeft();
        }

        public void MoveRight()
        {
            State.ChangeDirection();
            physics.MoveRight();
        }
    }
}
