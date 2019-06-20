using SuperMarioBros.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Koopas.States
{
    public class RightMovingKoopa : IEnemyState
    {
        private Koopa koopa;
        public RightMovingKoopa(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.Sprite = SpriteFactories.SpriteFactory.CreateSprite(this.GetType().Name);
        }

        public void ChangeDirection()
        {
            koopa.State = new LeftMovingKoopa(koopa);
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
