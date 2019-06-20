using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Physicses;
using System;

namespace SuperMarioBros.Goombas
{
    public class StompedGoomba : AbstractEnemy
    {
        private int timeLength;
        public StompedGoomba(Vector2 position)
        {
            State = new IdleEnemyState(this);
            Position = position;
            physics = new EnemyPhysics(this, new Vector2(0, 0));
            timeLength = 30;
        }
        
        public override void Update(GameTime gameTime)
        {
            timeLength--;
            IsInvalid = timeLength == 0;
            base.Update(gameTime);
        }

        public override void TakeDamage()
        {
           //Do Nothing
        }

        public override void Flip()
        {
            //Do Nothing
        }
    }
}
