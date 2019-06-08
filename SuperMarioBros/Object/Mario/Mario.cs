using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Marios
{
    public class Mario : IMario
    {
        private IMarioHealthState healthState;
        private IMarioMovementState movementState;
        private ISprite sprite;
        private readonly Physics physics;
        private Point location;
        public Mario(Point location)
        {
            healthState = new SmallMario(this);
            physics = new Physics(3, 3);
            this.location = location;
            movementState = new RightIdleMarioState(this, healthState.GetType().Name,physics);
        }
        public void ChangHealthState(IMarioHealthState healthState) // Help method for marioState
        {
            string type = healthState.GetType().Name;
            if (!type.Equals("DeadMario"))
            {
                movementState.ChangeSprite(type);
            }
            else
            {
                sprite = SpriteFactory.CreateSprite("DeadMario");
                movementState = new TerminateMovementState();
            }
            this.healthState = healthState;
        }
        
        public void ChangeSprite(ISprite sprite) // Help method for movementState
        {
            this.sprite = sprite;
        }
        public void ChangeMovementState(IMarioMovementState movementState) // Help method for movementState
        {
            this.movementState = movementState;
        }
        public void Down()
        {
            movementState.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void FireFlower()
        {
            healthState.FireFlower();
        }

        public void Left()
        {
            movementState.Left();
        }

        public void RedMushroom()
        {
            healthState.RedMushroom();
        }

        public void Right()
        {
            movementState.Right();
        }

        public void TakeDamage()
        {
            healthState.TakeDamage();
        }

        public void Up()
        {
            movementState.Up();
        }

        public void Update()
        {
            movementState.Update();
            sprite.Update();
            location += physics.Motion();
        }

        public void Idle()
        {
            movementState.Idle();
        }

        public Rectangle HitBox()
        {
            return new Rectangle(location.X, location.Y- sprite.Height(), sprite.Width(), sprite.Height());
        }

        public void GreenMushroom()
        {
            // TODO
        }

        public void Obstacle()
        {
            location -= physics.Revert();
        }

        public void Coin()
        {
            //Do Nothing
        }
    }
}
