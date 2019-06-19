using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Goombas
{
    public class Goomba : AbstractEnemy
    {
        public Goomba(Vector2 location)
        {
            Position = location;
            physics = new EnemyPhysics(this, new Vector2(-30, 0));
            State = new LeftMoving(this, physics);
        }

        public override void Flip()
        {
            ObjectsManager.Instance.AddNonCollidable(new FlippedGoomba(this));
            ObjectsManager.Instance.Remove(this);
        }

        public override void TakeDamage()
        {
            ObjectsManager.Instance.Add(new StompedGoomba(Position));
            ObjectsManager.Instance.Remove(this);
        }

    }
}
