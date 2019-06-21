using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Physicses
{
    public class EnemyPhysics
    {
        public Vector2 velocity;
        private readonly float gravity = 600;
        private Vector2 displacement;
        private Vector2 prevDisplacement;
        private float dt = 0;
        private readonly IObject obj;
        public EnemyPhysics(IObject obj, Vector2 velocity)
        {
            this.velocity = velocity;
            this.obj = obj;
            displacement = new Vector2(0, 0);
            prevDisplacement = displacement;
        }
        public void MoveUp()
        {
            obj.Position -= new Vector2(0, prevDisplacement.Y);
            velocity.Y = 0;
        }
        public void MoveLeft()
        {
            obj.Position -= new Vector2(3*prevDisplacement.X, 0);
            velocity.X *= -1;
        }
        public void MoveRight()
        {
            obj.Position -= new Vector2(3*prevDisplacement.X, 0);
            velocity.X *= -1;
        }
        public void MoveDown()
        {
            obj.Position -= new Vector2(0, prevDisplacement.Y);
            velocity.Y *= -1;
        }

        public Vector2 Displacement(GameTime gameTime)
        {
            Update(gameTime);
            prevDisplacement = displacement;
            displacement = new Vector2(0, 0);                  
            return prevDisplacement;   
        }

        private void Update(GameTime gameTime)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity.Y += gravity * dt;
            displacement.X += (velocity.X * dt);
            displacement.Y += (velocity.Y * dt);          
        }
        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }
        public void BumpUp()
        {
            velocity.Y = -100;
        }

    }
}
