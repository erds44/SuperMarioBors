using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Physicses
{
    public class EnemyPhysics
    {
        public float XVelocity { get; private set; }
        public float YVelocity { get; private set; }
        private readonly float gravity = 120;
        private Vector2 displacement;
        private Vector2 prevDisplacement;
        private float dt = 0;
        private readonly IObject obj;
        public EnemyPhysics(IObject obj, float XVelocity, float YVelocity)
        {
            this.XVelocity = XVelocity;
            this.YVelocity = YVelocity;
            this.obj = obj;
            displacement = new Vector2(0, 0);
            prevDisplacement = displacement;
        }
        public void MoveUp()
        {
            obj.Position -= new Vector2(0, prevDisplacement.Y);
            YVelocity = 0;
        }
        public void MoveLeft()
        {
            obj.Position -= new Vector2(3*prevDisplacement.X, 0);
            XVelocity *= -1;
        }
        public void MoveRight()
        {
            obj.Position -= new Vector2(3*prevDisplacement.X, 0);
            XVelocity *= -1;
        }
        public void MoveDown()
        {
            obj.Position -= new Vector2(0, prevDisplacement.Y);
            YVelocity *= -1;
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
            YVelocity += gravity * dt;
            displacement.X += (XVelocity * dt);
            displacement.Y += (YVelocity * dt);          
        }

    }
}
