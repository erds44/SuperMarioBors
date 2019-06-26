using Microsoft.Xna.Framework;

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
        public override void Stomped()
        {
            IsStomped = true;
            DealDemage = false;
            HealthState.Stomped();
            MovementState.Stomped();
        }
        public override void Update(GameTime gameTime)
        {
            MovementState.Update(gameTime);
            base.Update(gameTime);
        }
    }
}

