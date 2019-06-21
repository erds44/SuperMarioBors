using SuperMarioBros.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Koopas.States
{
    public class StompedMovingKoopa : IEnemyState
    {
        private Koopa koopa;
        public StompedMovingKoopa(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.Sprite = SpriteFactories.SpriteFactory.CreateSprite(this.GetType().Name);
            koopa.physics.SetVelocity(100, 0);
        }

        public void ChangeDirection()
        {
            koopa.physics.ReverseVelocity();
        }

        public void Stomped()
        {
            koopa.State = new StompedKoopa(koopa);
        }

        public void TakeDamage()
        {
            koopa.Flip();
        }
    }
}
