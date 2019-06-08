using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Marios
{
    public class StarMario : IMario
    {
        public IMarioHealthState HealthState { get; set; }
        public IMarioMovementState MovementState { get; set; }
        public Physics MarioPhysics { get; }
        private readonly IMario mario;
        public ISprite Sprite { get; set; }
        private int timer;
        public StarMario(IMario mario)
        {
            this.mario = mario;
            MarioPhysics = mario.MarioPhysics;
            timer = 300;
        }

        public void Down()
        {
            mario.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite = new DecorationSprite(mario.Sprite);
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
            timer--;
            if(timer == 0)
            {
                ObjectsManager.Instance.DecorateMario(mario);
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
