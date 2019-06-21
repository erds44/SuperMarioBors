using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Physicses;

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
            ObjectsManager.Instance.AddObject(new StompedKoopa(Position));
            IsInvalid = true;
        }
        
        public override void Flip()
        {
            ObjectsManager.Instance.AddNonCollidable(new FlippedKoopa(this));
            IsInvalid = true;
        }

        public override void MoveLeft()
        {
            State.ChangeDirection();
            physics.MoveLeft();
        }

        public override void MoveRight()
        {
            State.ChangeDirection();
            physics.MoveRight();
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update();
            Position += physics.Displacement(gameTime);       
        }
    }
}
