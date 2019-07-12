using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Objects.Enemy
{
    public abstract class AbstractEnemy : IEnemy
    {
        public int EnemyKillStreakCounter { get; set; }
        public IEnemyMovementState MovementState { get; set; }
        public IEnemyHealthState HealthState { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Physics Physics { get; set; }
        public ObjectState ObjState { get; set; }
        private protected bool IsFlipped;
        private protected Vector2 initialVelocity = PhysicsConsts.EnemyInitialVelocity;
        private protected float enemyGravity = PhysicsConsts.EnemyGravity;
        private protected float enemyWeight = PhysicsConsts.EnemyWeight;
        public int Score { get; set; }
        public Rectangle HitBox { get => EnemyHitBox(); }
        protected void Initialize()
        {
            ObjState = ObjectState.Normal;
            Physics = new Physics(Vector2.Zero, enemyGravity, enemyWeight);
            Physics.ApplyGravity();
            IsFlipped = false;
            Score = Utilities.DefaultEnmeyScore;
            EnemyKillStreakCounter = Utilities.DefaultEnmeyCount;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsFlipped)
                ((UniversalSprite)Sprite).Draw(spriteBatch, Position, SpriteEffects.FlipVertically);
            else
                Sprite.Draw(spriteBatch, Position);
        }
        public virtual Rectangle EnemyHitBox()
        {
            Point size = SpriteFactory.ObjectSize(MovementState.GetType().Name);
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }
        public void Destroy() { }

        public virtual void Update(GameTime gameTime)
        {
            Position += Physics.Displacement(gameTime);
            Sprite.Update(gameTime);
        }
        public virtual void ChangeDirection()
        {
            MovementState.ChangeDirection();
        }
        public virtual void Stomped() { }

        public virtual void Flipped()
        {
            IsFlipped = true;
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
