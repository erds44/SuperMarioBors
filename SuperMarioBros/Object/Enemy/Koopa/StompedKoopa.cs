using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Koopas
{
    public class StompedKoopa : AbstractEnemy
    {
        private double respawnTimer = 5;
        public bool DealDamge { get; private set;} /* a flag to check if stompedkoopa would deal mario */
        public StompedKoopa(Vector2 location)
        {
            Position = location;
            State = new IdleEnemyState(this);
            physics = new EnemyPhysics(this, new Vector2(0, 0));
            DealDamge = false;
        }

        public override void TakeDamage()
        {
            IsInvalid = true;
        }

        public override void Update(GameTime gameTime)
        {
            respawnTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (respawnTimer < 0 && State is IdleEnemyState)
            {
                ObjectsManager.Instance.AddDynamic(new Koopa(Position));   /* return to Koopa after 5 seconds */
                IsInvalid = true;
            }
            Position += physics.Displacement(gameTime);
        }

        public override void Flip()
        {
            IsInvalid = true;
        }

        public override void MoveLeft()
        {
            if (State is IdleEnemyState) /* Inital setup when Mario kick shell */             
            {
                physics.SetVelocity(new Vector2(-160, 0));
                State = new LeftMoving(this, physics);
            }
            else /* Collision response */
            {
                physics.MoveLeft();
                State.ChangeDirection();
                SetDealDamage();
            }
        }

        public override void MoveRight()
        {
            if (State is IdleEnemyState) /* Inital setup when Mario kick shell */
            {
                physics.SetVelocity(new Vector2(120, 0));
                State = new RightMoving(this, physics);
            }
            else /* Collision response */
            {
                physics.MoveRight();
                State.ChangeDirection();
                SetDealDamage();
            }
        }
        private void SetDealDamage()
        {
            DealDamge = true;
        }
    }
}
