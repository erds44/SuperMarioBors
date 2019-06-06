using System;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Koopas.KoopaStates
{
    public class LeftMovingKoopaState : IEnemyState
    {
        private readonly Koopa koopa;
        public LeftMovingKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.ChangeSprite(SpriteFactory.CreateSprite("KoopaMovingLeft"));
        }
        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            koopa.ChangeState(new KoopaStompedState(koopa));
        }

        public void ChangeDirection()
        {
            koopa.ChangeState(new RightMovingGoombaState(koopa));
           // More to do
        }
    }
}
