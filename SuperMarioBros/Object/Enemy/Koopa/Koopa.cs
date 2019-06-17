using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Koopas
{
    public class Koopa : AbstractEnemy
    {
        public Koopa(Vector2 location)
        {
            physics = new ObjectPhysics(this, -40, 0);
            State = new LeftMoving(this, physics);
            Position = location;
        }
    }
}
