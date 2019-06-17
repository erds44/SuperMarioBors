using Microsoft.Xna.Framework;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Goombas
{
    public class Goomba : AbstractEnemy
    {
        public Goomba(Vector2 location)
        {
            Position = location;
            physics = new EnemyPhysics(this, -30, 0);
            State = new LeftMoving(this, physics);
        }

    }
}
