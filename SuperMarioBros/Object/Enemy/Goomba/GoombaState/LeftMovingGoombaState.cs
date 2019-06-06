using System;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class LeftMovingGoombaState : IEnemyState
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
            goomba.ChangeState(new GoombaStompedState(goomba));
        }

        public void ChangeDirection()
        {
            goomba.ChangeState(new RightMovingGoombaState(goomba));
            // More to do
        }

    }
}
