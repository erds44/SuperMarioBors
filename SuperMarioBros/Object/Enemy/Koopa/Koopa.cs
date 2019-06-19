using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Goombas;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Koopas
{
    public class Koopa : AbstractEnemy
    {
        public Koopa(Vector2 location)
        {
            physics = new EnemyPhysics(this, new Vector2(-30, 0));
            State = new LeftMoving(this, physics);
            Position = location;
        }

        public override void TakeDamage()
        {
            ObjectsManager.Instance.Add(new StompedKoopa(Position));
            ObjectsManager.Instance.Remove(this);
        }
        
        public override void Flip()
        {
            ObjectsManager.Instance.AddNonCollidable(new FlippedKoopa(this));
            ObjectsManager.Instance.Remove(this);
        }
    }
}
