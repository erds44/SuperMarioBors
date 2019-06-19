using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Physicses;
using System;

namespace SuperMarioBros.Goombas
{
    public class StompedGoomba : AbstractEnemy
    {
        private float timeLength;
        public StompedGoomba(Vector2 position)
        {
            State = new IdleEnemyState(this);
            Position = position;
            physics = new EnemyPhysics(this, new Vector2(0, 0));
            timeLength = 0;
        }

        public bool Delete(GameTime gameTime)
        {
            timeLength += (float)gameTime.ElapsedGameTime.TotalSeconds;
            return timeLength > 0.3;
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
