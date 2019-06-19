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
        public bool IsInvalid { get; set; }
        public bool PowerFlag { get; set; }
        public IMarioHealthState HealthState { get; set; }
        public IMarioMovementState MovementState { get; set; }
        public ISprite Sprite { get; set; }
        public MarioPhysics MarioPhysics { get; }
        public Vector2 Position { get; set; }
        public double Timer { get; set; }
        public Mario(Vector2 location)
        {
            HealthState = new SmallMario(this);
            MarioPhysics = new MarioPhysics(this,100);
            MovementState = new RightIdle(this);
            Position = location;
        }


        public void Down()
        {
            MovementState.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Sprite.Draw(spriteBatch, location);
            Sprite.Draw(spriteBatch, Position);
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


        public void Coin()
        {
            HealthState.Coin();
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update();
            HealthState.Update(gameTime);
            Position += MarioPhysics.Displacement(gameTime);
        }

        public void MoveUp()
        {
            MovementState.MoveUp();
        }

        public void MoveDown()
        {
            MovementState.MoveDown();
        }

        public void MoveLeft()
        {
            MovementState.MoveLeft();
        }

        public void MoveRight()
        {
            MovementState.MoveRight();
        }

        public void Destroy()
        {
            //Do nothing.
        }
    }
}
