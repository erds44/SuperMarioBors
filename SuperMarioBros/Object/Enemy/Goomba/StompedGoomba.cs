using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas.GoombaStates;

namespace SuperMarioBros.Goombas
{
    public class StompedGoomba : AbstractEnemy
    {
        public StompedGoomba(Point position)
        {
            State = new IdleEnemyState(this);
            this.location = position;
        }

    }
}
