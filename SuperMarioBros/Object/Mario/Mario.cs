using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
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
        private Point location;
        public Mario(Point location)
        {
            HealthState = new SmallMario(this);
            MarioPhysics = new Physics(3, 3);
            MovementState = new RightIdle(this, MarioPhysics);
            this.location = location;
        }


        public void Down()
        {
            MovementState.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, location);
        }

        public void FireFlower()
        {
            HealthState.FireFlower();
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
            MovementState.Update();
            Sprite.Update();
            location += MarioPhysics.Motion();
        }

        public void Idle()
        {
            MovementState.Idle();
        }

        public Rectangle HitBox()
        {
            return new Rectangle(location.X, location.Y- Sprite.Height(), Sprite.Width(), Sprite.Height());
        }

        public void GreenMushroom()
        {
            // TODO
        }

        public void Obstacle()
        {
            location -= MarioPhysics.Revert();
        }

        public void Coin()
        {
            HealthState.Coin();
        }
    }
}
