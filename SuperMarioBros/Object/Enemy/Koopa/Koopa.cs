using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Koopas
{
    public class Koopa : AbstractEnemy
    {
        public Koopa(Vector2 location)
        {
            State = new LeftMoving(this);
            Position = location;
        }
    }
}
