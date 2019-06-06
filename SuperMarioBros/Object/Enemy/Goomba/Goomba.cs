using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas.GoombaStates;

namespace SuperMarioBros.Goombas
{
    public class Goomba : AbstractEnemy
    {
        public Goomba( Point location)
        {
            state = new LeftMovingEnemyState(this);
            this.location = location;
        }

    }
}
