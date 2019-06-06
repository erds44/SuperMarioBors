using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Marios
{
    public class StarMario : IMario
    {
        private readonly IMario mario;
        private readonly ISprite sprite;
        private Point location;
        private int timer;
        public StarMario(IMario mario)
        {
            this.mario = mario;
            sprite = SpriteFactory.CreateSprite("Star");
            timer = 300;
            // Change Sprite
        }
        public void ChangeMarioState(IMarioState marioState) // Help method for marioState
        {
            mario.ChangeMarioState(marioState);
        }
        
        public void ChangeSprite(ISprite sprite) // Help method for movementState
        {
            mario.ChangeSprite(sprite);
        }
        public void ChangeMovementState(IMarioMovementState movementState) // Help method for movementState
        {
            mario.ChangeMovementState(movementState);
        }
        public void Down()
        {
            mario.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Draw(spriteBatch);
            sprite.Draw(spriteBatch, location);
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
                location.X = mario.HitBox().X + 10;
                location.Y = mario.HitBox().Y - 5;
                sprite.Update();
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
