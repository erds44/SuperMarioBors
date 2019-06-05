using System;
using SuperMarioBros.GoombaStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class LeftMovingGoombaState : IGoombaState
    {
        private readonly Goomba goomba;
        public LeftMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            goomba.ChangeSprite(SpriteFactory.CreateSprite("Goomba"));
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
            goomba.ChangeState(new RightMovingGoombaState(goomba));
            // More to do
        }

    }
}
