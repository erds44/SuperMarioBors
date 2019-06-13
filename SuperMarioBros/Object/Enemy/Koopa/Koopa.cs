using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Koopas
{
    public class Koopa : AbstractEnemy
    {
        public Koopa(Point location)
        {
            State = new LeftMoving(this);
            this.location = location;
        }
    }
}
