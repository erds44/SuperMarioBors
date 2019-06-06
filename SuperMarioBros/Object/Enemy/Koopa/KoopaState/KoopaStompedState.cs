using System;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Koopas.KoopaStates
{
    public class KoopaStompedState : IEnemyState
    {
        private readonly Koopa koopa;
        public KoopaStompedState (Koopa koopa)
        {
            this.koopa = koopa;
            koopa.ChangeSprite(SpriteFactory.CreateSprite("KoopaStomped"));
        }
        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            // Do Nothing
        }

        public void ChangeDirection()
        {
           koopa.ChangeState(new LeftMovingKoopaState(koopa));
            // More to do
        }
    }
}
