using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Objects.Enemy
{
    public class Koopa : AbstractEnemy
    {
        public bool IsStomped { get; set; }
        public bool DealDemage { get; set; }
        public Koopa(Vector2 location)
        {
            Position = location;
            DealDemage = true;
            base.Initialize();
            HealthState = new KoopaNormalState(this);
            if (initialVelocity.X <= 0) MovementState = new KoopaLeftMovingState(this);
            else MovementState = new KoopaRightMovingState(this);
        }
        public override void Stomped(int count)
        {
            IsStomped = true;
            DealDemage = false;
            HealthState.Stomped();
            MovementState.Stomped();
            base.Stomped(count);
        }
        public override void Update(GameTime gameTime)
        {
            MovementState.Update(gameTime);
            base.Update(gameTime);
        }
        public override Rectangle HitBox()
        {
            Point size = SpriteFactory.ObjectSize(HealthState.GetType().Name + MovementState.GetType().Name);
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }
    }
}

