using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Classes.Object.MarioObject
{
    public class StarMario : IMario
    {
        private readonly IMario mario;
        private readonly ISprite sprite;
        private Vector2 location;
        private int timer;
        private readonly ObjectsManager objectsManager;
        public StarMario(IMario mario, ObjectsManager objectsManager)
        {
            this.mario = mario;
            sprite = SpriteFactory.CreateSprite("Star");
            timer = 300;
            this.objectsManager = objectsManager;
            // Change Sprite
        }
        public void ChangeMarioState(IMarioState marioState) // Help method for marioState
        {
            /*
            string type = marioState.GetType().ToString().Substring(42);
            this.marioState = marioState;
            movementState.ChangeSprite(type);
            if (type.Equals("DeadMario"))
            {
                movementState = new TerminateMovementState();
            }
            */
            mario.ChangeMarioState(marioState);
        }
        
        public void ChangeSprite(ISprite sprite) // Help method for movementState
        {
            /*
            this.sprite = sprite;
            */
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
            /*
            marioState.FireFlower();
            */
            mario.FireFlower();
        }

        public void Left()
        {
            mario.Left();
        }

        public void RedMushroom()
        {
            /*marioState.RedMushroom();
             */
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
                objectsManager.DecorateMario(mario);
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
    }
}
