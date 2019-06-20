using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using System;

namespace SuperMarioBros.Koopas
{
    public class StompedKoopa : AbstractEnemy
    {
        private float timeLength;
        public bool NotKicked { get; set; }
        public StompedKoopa(Vector2 location)
        {
            Position = location;
            State = new IdleEnemyState(this);
            physics = new EnemyPhysics(this, new Vector2(0, 0));
            timeLength = 0;
            NotKicked = true;

            Console.WriteLine(this.GetType());
        }
        
        public override void MoveLeft()
        {
            physics.velocity.X = -100;
            NotKicked = false;
            //physics.MoveLeft();
        }

        public override void MoveRight()
        {
            physics.velocity.X = 100;
            NotKicked = false;
           // physics.MoveRight();
        }

        public override void TakeDamage()
        {
            ObjectsManager.Instance.Remove(this);
        }

        public bool Delete(GameTime gameTime)
        {
            timeLength += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeLength > 5 && NotKicked)
                ObjectsManager.Instance.Add(new Koopa(Position));
            return timeLength > 5 && NotKicked;
        }

        public override void Flip()
        {
            ObjectsManager.Instance.Remove(this);
        }
    }
}
