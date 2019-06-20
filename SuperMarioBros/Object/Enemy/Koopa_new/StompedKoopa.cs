using SuperMarioBros.Enemy;
using System;

namespace SuperMarioBros.Koopas.States
{
    public class StompedKoopa : IEnemyState
    {
        public int timeLength;
        private Koopa koopa;
        public StompedKoopa(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.Sprite = SpriteFactories.SpriteFactory.CreateSprite(this.GetType().Name);
            koopa.physics.StopMoving();
            timeLength = 120;
        }

        public void ChangeDirection()
        {
            // Do nothing.
        }

        public void Stomped()
        {
            koopa.State = new StompedMovingKoopa(koopa);
        }

        public void TakeDamage()
        {
            koopa.Flip();
        }
    }
}
