using Microsoft.Xna.Framework;
using SuperMarioBros.Managers;
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
            ObjectsManager.Instance.AddNonCollidableObject(new FlippedGoomba(this));
            ObjState = ObjectState.Destroy;
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

        public override void TakeDamage()
        {
            ObjectsManager.Instance.AddObject(new StompedGoomba(Position));
            ObjState = ObjectState.Destroy;;
        }
        public override void Update(GameTime gameTime)
        {
            Sprite.Update();
            Position += physics.Displacement(gameTime);
        }

    }
}
