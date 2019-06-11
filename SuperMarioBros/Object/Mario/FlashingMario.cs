using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Marios
{
    public class FlashingMario : IMario
    {
        public IMarioHealthState HealthState { get; set; }
        public IMarioMovementState MovementState { get; set; }
        public Physics MarioPhysics { get; }
        private readonly IMario mario;
        public ISprite Sprite { get; set; }
        public int Timer { get; set; }
        private readonly int index;
        public FlashingMario(IMario mario, int index)
        {
            this.mario = mario;
            MarioPhysics = mario.MarioPhysics;
            Timer = 100;
            this.index = index;
        }

        public void Down()
        {
            mario.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite = new FlashingSprite(mario.Sprite);
            Sprite.Draw(spriteBatch, new Point(mario.HitBox().X, mario.HitBox().Y + mario.HitBox().Height));
        }

        public void FireFlower()
        {
            mario.FireFlower();
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

        public void Update()
        {
            mario.Update();
            Timer--;
            if(Timer <= 0)
            {
                ObjectsManager.Instance.DecorateMario(mario, index);
            }
            else
            {
                Sprite.Update();
            }
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

        public void Obstacle()
        {
            mario.Obstacle();
        }

        public void Coin()
        {
            mario.Coin();
        }
    }
}
