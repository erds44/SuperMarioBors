using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Managers;
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
        public double NoMovementTimer { get; set; }
        public Mario(Vector2 location)
        {
            HealthState = new SmallMario(this);
            MarioPhysics = new MarioPhysics(this,150);
            MovementState = new RightIdle(this);
            Position = location;
            NoMovementTimer = 0;
        }


        public void Down()
        {
            if(NoMovementTimer <= 0)
                MovementState.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void OnFireFlower()
        {
            HealthState.OnFireFlower();
        }

        public void Left()
        {
            if (NoMovementTimer <= 0)
                MovementState.Left();
        }

        public void RedMushroom()
        {
            HealthState.RedMushroom();
        }

        public void Right()
        {
            if (NoMovementTimer <= 0)
                MovementState.Right();
        }

        public void TakeDamage()
        {
            HealthState.TakeDamage();
        }

        public void Up()
        {
            if (NoMovementTimer <= 0)
                MovementState.Up();
        }


        public void Idle()
        {
            if (NoMovementTimer <= 0)
                MovementState.Idle();
        }

        public Rectangle HitBox()
        {
            Point size = SizeManager.MarioSize(HealthState.GetType(), MovementState.GetType());
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
            HealthState.Update(gameTime);
            MovementState.Update();
            Sprite.Update();
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
            MarioGame.Instance.InitializeGameComponents();
        }

        public IMario ReturnItself()
        {
            return this;
        }
        public void BumpUp()
        {
            MovementState.BumpUp();
        }
    }
}
