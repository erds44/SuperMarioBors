using System;
using SuperMarioBros.GoombaStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Koopas.KoopaStates
{
    public class RightMovingGoombaState : IGoombaState
    {
        private readonly Koopa koopa;
        public RightMovingGoombaState(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.ChangeSprite(SpriteFactory.CreateSprite("KoopaMovingRight"));
        }
        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            throw new NotImplementedException();
        }

        public void ChangeDirection()
        {
           koopa.ChangeState(new LeftMovingKoopaState(koopa));
            // More to do
        }
    }
}
