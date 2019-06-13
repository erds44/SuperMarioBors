using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;

namespace SuperMarioBros.Koopas
{
    public class StompedKoopa : AbstractEnemy
    {
        public StompedKoopa(Point location)
        {
            this.location = location;
            State = new IdleEnemyState(this);
        }
    }
}
