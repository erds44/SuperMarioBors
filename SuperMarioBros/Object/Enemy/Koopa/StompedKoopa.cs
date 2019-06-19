using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Koopas
{
    public class StompedKoopa : AbstractEnemy
    {
        private float timeLength;
        public StompedKoopa(Vector2 location)
        {
            Position = location;
            State = new IdleEnemyState(this);
            physics = new EnemyPhysics(this, new Vector2(0, 0));
            timeLength = 0;
        }
        //StompedKoopa will return to Koopa if not kicked


        public override void TakeDamage()
        {
            ObjectsManager.Instance.Remove(this);
        }

        public bool Delete(GameTime gameTime)
        {
            timeLength += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeLength > 5)
                ObjectsManager.Instance.Add(new Koopa(Position));
            return timeLength > 5;
        }

        public override void Flip()
        {
            ObjectsManager.Instance.Remove(this);
        }
    }
}
