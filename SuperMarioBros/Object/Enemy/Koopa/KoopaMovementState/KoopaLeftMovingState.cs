using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Objects.Enemy
{
    public class KoopaLeftMovingState : IEnemyMovementState
    {
        private readonly Koopa koopa;
        public KoopaLeftMovingState(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.Sprite = SpriteFactory.CreateSprite(koopa.HealthState.GetType().Name + GetType().Name);
            if(koopa.HealthState is KoopaNormalState)
                koopa.Physics.Velocity = PhysicsConsts.LeftMovingNormalKoopaVelocity;
            else
                koopa.Physics.Velocity = PhysicsConsts.LeftMovingShelledKoopaVelocity;
            koopa.Score = GeneralConstants.DefaultEnmeyScore;
        }

        public void ChangeDirection()
        {
            koopa.DealDemage = false;
            koopa.MovementState = new KoopaRightMovingState(koopa);
        }

        public void MoveLeft()
        {
            koopa.MovementState = new KoopaLeftMovingState(koopa);
        }

        public void MoveRight()
        {
            koopa.MovementState = new KoopaRightMovingState(koopa);
        }

        public void Stomped()
        {
            koopa.MovementState = new KoopaIdleState(koopa);
        }

        public void Update(GameTime gameTime) { }
    }
}
