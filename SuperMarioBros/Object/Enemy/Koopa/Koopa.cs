using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Object.Enemy;

namespace SuperMarioBros.Koopas
{
    public class Koopa : AbstractEnemy, IEnemy
    {
        public Koopa(Vector2 location)
        {
            state = new LeftMovingEnemyState(this);
            this.location = location;
        }
    }
}
