using System;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class GoombaStompedState : IEnemyState
    {
        private readonly Goomba goomba;
        public GoombaStompedState(Goomba goomba)
        {
            this.goomba = goomba;
            goomba.ChangeSprite(SpriteFactory.CreateSprite("GoombaStomped"));
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
            // Do Nothing
        }
    }
}
