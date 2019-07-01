using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects.Enemy
{
    public class Goomba : AbstractEnemy
    {
        public Goomba(Vector2 location)
        {
            Position = location;
            base.Initialize();
            HealthState = new GoombaNormalState(this);
            if (initialVelocity.X <= 0) MovementState = new GoombaLeftMovingState(this);
            else MovementState = new GoombaRightMovingState(this);
        }
        public override void Stomped(int count)
        {
            HealthState.Stomped();
            MovementState.Stomped();
            base.Stomped(count);
        }
        public override void Update(GameTime gameTime)
        {
            HealthState.Update(gameTime);
            base.Update(gameTime);
        }

    }
}
