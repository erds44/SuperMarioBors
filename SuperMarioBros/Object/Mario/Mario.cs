using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Marios
{
    public class Mario : IMario
    {
        public IMarioHealthState HealthState { get; set; }
        public IMarioMovementState MovementState { get; set; }
        public ISprite Sprite { get; set; }
        public Physics MarioPhysics { get; }
        public Vector2 Position { get; set; }
        public int Timer { get; set; }
        public Mario(Point location)
        {
            HealthState = new SmallMario(this);
            MarioPhysics = new Physics(100);
            MovementState = new RightIdle(this);
            Position = new Vector2((float)location.X, (float)location.Y);
        }


        public void Down()
        {
            MovementState.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Sprite.Draw(spriteBatch, location);
            Sprite.Draw(spriteBatch, new Point((int) Position.X, (int)Position.Y));
        }

        public void OnFireFlower()
        {
            HealthState.OnFireFlower();
        }

        public void Left()
        {
            MovementState.Left();
        }

        public void RedMushroom()
        {
            HealthState.RedMushroom();
        }

        public void Right()
        {
            MovementState.Right();
        }

        public void TakeDamage()
        {
            HealthState.TakeDamage();
        }

        public void Up()
        {
            MovementState.Up();
        }

        public void Update()
        {
            //MovementState.Update();
            //Sprite.Update();
            //location += MarioPhysics.Displacement();
        }

        public void Idle()
        {
            MovementState.Idle();
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.MarioSize(HealthState.GetType(), MovementState.GetType());
            return new Rectangle((int)Position.X, (int)Position.Y- size.Y, size.X, size.Y);
        }

        public void GreenMushroom()
        {
            // TODO
        }

        public void Obstacle(Direction direction)
        {
            MarioPhysics.CollisionDirection = direction;
            MovementState.Obstacle(direction);
        }

        public void Coin()
        {
            HealthState.Coin();
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update();
           // location += MarioPhysics.Displacement(gameTime);
            Position += MarioPhysics.Displacement(gameTime);
        }

    }
}
