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
        public int stompedCount { get; set; }
        public int count { get; set; }
        public StompedKoopa(Vector2 location)
        {
            Position = location;
            State = new IdleEnemyState(this);
            physics = new EnemyPhysics(this, new Vector2(0, 0));
            DealDamge = false;
            stompedCount = 0;
            count = 0;
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
                ObjectsManager.Instance.AddObject(new Koopa(Position));   /* return to Koopa after 5 seconds */
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

                    Position += new Vector2(-30, 0);
                    physics.SetVelocity(new Vector2(-220, 0));
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
                    Position += new Vector2(30, 0);
                    physics.SetVelocity(new Vector2(220, 0));
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
        public void Idle()
        {
            physics.SetVelocity(new Vector2(0, 0));
            State = new IdleEnemyState(this);
            respawnTimer = 5;
            DealDamge = false;

        }
    }
}
