using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Marios
{
    public class FlashingMario : IMario
    {
        public bool IsInvalid { get; set; }
        public IMarioHealthState HealthState { get; set; }
        public IMarioMovementState MovementState { get; set; }
        public MarioPhysics MarioPhysics { get; }
        private readonly IMario mario;
        public ISprite Sprite { get; set; }
        public double Timer { get; set; }
        public Vector2 Position { get; set; }
        public bool PowerFlag { get => mario.PowerFlag; set => mario.PowerFlag = value; }
        public double NoMovementTimer { get; set; }

        public FlashingMario(IMario mario)
        {
            this.mario = mario;
            this.HealthState = mario.HealthState;
            MarioPhysics = mario.MarioPhysics;
            HealthState = mario.HealthState;
            Timer = 3;
            mario.NoMovementTimer = 1;
            NoMovementTimer = 1.5;
        }

        public void Down()
        {
                mario.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite = new FlashingSprite(mario.Sprite);
            Sprite.Draw(spriteBatch, new Vector2(mario.HitBox().X, mario.HitBox().Y + mario.HitBox().Height));
        }

        public void OnFireFlower()
        {
            mario.OnFireFlower();
        }

        public void Left()
        {

           mario.Left();

        }

        public void RedMushroom()
        {
            mario.RedMushroom();
        }

        public void Right()
        {
            mario.Right();
        }

        public void TakeDamage()
        {
            // Do Nothing
        }

        public void Up()
        {
             mario.Up();
        }


        public void Idle()
        {
            mario.Idle();
        }

        public Rectangle HitBox()
        {
            return mario.HitBox();
        }

        public void GreenMushroom()
        {
            // TODO
        }


        public void Coin()
        {
            mario.Coin();
        }

        public void Update(GameTime gameTime)
        {
            if (NoMovementTimer <= 0)
            {
                mario.NoMovementTimer = 0;
                mario.Update(gameTime);
                Sprite.Update();
            }
            else
            {
                mario.MarioPhysics.SetXVelocity(0);
            }
            if (Timer <= 0)
            {
                ObjectsManager.Instance.Decoration(this, mario);
            }
            NoMovementTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            Timer -= gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void MoveUp()
        {
            mario.MoveUp();
        }

        public void MoveDown()
        {
            mario.MoveDown();
        }

        public void MoveLeft()
        {
            mario.MoveLeft();
        }

        public void MoveRight()
        {
            mario.MoveRight();
        }

        public void Destroy()
        {
            //Do nothing.
        }

        public IMario ReturnItself()
        {
            return mario;
        }

        public void BumpUp()
        {
           // Do Nothing
        }
    }
}
