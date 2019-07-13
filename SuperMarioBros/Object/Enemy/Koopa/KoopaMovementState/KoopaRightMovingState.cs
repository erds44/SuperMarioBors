using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Objects.Enemy
{
    public class KoopaRightMovingState : IEnemyMovementState
    {
        private readonly Koopa koopa;
        public KoopaRightMovingState(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.Sprite = SpriteFactory.CreateSprite(koopa.HealthState.GetType().Name + GetType().Name);
            if (koopa.HealthState is KoopaNormalState)
                koopa.Physics.Velocity = PhysicsConsts.RightMovingNormalKoopaVelocity;
            else
                koopa.Physics.Velocity = PhysicsConsts.RightMovingShelledKoopaVelocity;
            koopa.Score = GeneralConstants.DefaultEnemyScore;
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
