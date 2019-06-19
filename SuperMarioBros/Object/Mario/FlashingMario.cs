using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
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
        private  IMario mario;
        public ISprite Sprite { get; set; }
        public double Timer { get; set; }
        public Vector2 Position { get; set; }
        public bool PowerFlag { get => mario.PowerFlag; set => mario.PowerFlag = value; }

        public FlashingMario(IMario mario)
        {
            this.mario = mario;
            this.HealthState = mario.HealthState;
            MarioPhysics = mario.MarioPhysics;
            HealthState = mario.HealthState;
            Timer = 5;
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

        //public void Update()
        //{
        //    mario.Update();
        //    Timer--;
        //    if(Timer <= 0)
        //    {
        //        ObjectsManager.Instance.RemoveDecoration(this, mario);
        //    }
        //    else
        //    {
        //        Sprite.Update();
        //    }
        //}

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
            mario.Update(gameTime);
            Timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (Timer <= 0)
            {
                ObjectsManager.Instance.RemoveDecoration(this, mario);
            }
            else
            {
                Sprite.Update();
            }
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
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}
