using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Objects.Enemy
{
    public class KoopaRightMovingState : IEnemyMovementState
    {
        private readonly Koopa koopa;
        private readonly Vector2 NormalStateVelocity = new Vector2(80, 0);
        private readonly Vector2 ShelledStateVelocity = new Vector2(160, 0);
        public KoopaRightMovingState(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.Sprite = SpriteFactory.CreateSprite(koopa.HealthState.GetType().Name + GetType().Name);
            if (koopa.HealthState is KoopaNormalState)
                koopa.Physics.Velocity = NormalStateVelocity;
            else
                koopa.Physics.Velocity = ShelledStateVelocity;
            koopa.Score = 100;
        }
        public void ChangeDirection()
        {
            koopa.DealDemage = false;
            koopa.MovementState = new KoopaLeftMovingState(koopa);
        }

        public void Stomped()
        {
            koopa.MovementState = new KoopaIdleState(koopa);
        }

        public void Update(GameTime gameTime) { }

        public void MoveLeft()
        {
            koopa.MovementState = new KoopaLeftMovingState(koopa);
        }

        public void MoveRight()
        {
            koopa.MovementState = new KoopaRightMovingState(koopa);
        }
    }
}
