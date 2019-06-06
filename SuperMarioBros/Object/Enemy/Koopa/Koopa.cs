using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;

namespace SuperMarioBros.Koopas
{
    public class Koopa : AbstractEnemy
    {
        public Koopa(Point location)
        {
            state = new LeftMovingEnemyState(this);
            this.location = location;
        }
    }
}
