using System;
using SuperMarioBros.GoombaStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Koopas.KoopaStates
{
    public class LeftMovingKoopaState : IGoombaState
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
            throw new NotImplementedException();
        }

        public void ChangeDirection()
        {
            koopa.ChangeState(new RightMovingGoombaState(koopa));
           // More to do
        }
    }
}
