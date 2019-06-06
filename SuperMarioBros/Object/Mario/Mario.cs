using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Marios
{
    public class Mario : IMario
    {
        private IMarioState marioState;
        private IMarioMovementState movementState;
        private ISprite sprite;
        private readonly Physics marioPhysics;
        public Mario(Vector2 location)
        {
            marioState = new SmallMario(this);
            /*
             * Hard Code for now
             * Since GetType().ToString() returns the whole namespace
             * i.e.: SuperMarioBros.Classes.Object.MarioObject.SmallMario
             */
            marioPhysics = new Physics(
                new Vector2(0, -1),
                new Vector2(0, 1),
                new Vector2(-1,0),
                new Vector2(1, 0),
                location
                );
            movementState = new RightIdleMarioState(this, marioState.GetType().ToString().Substring(38),marioPhysics);
        }
        public void ChangeMarioState(IMarioState marioState) // Help method for marioState
        {
            string type = marioState.GetType().ToString().Substring(38);
            movementState.ChangeSprite(type);
            this.marioState = marioState;
            if (marioState is DeadMario)
            {
                movementState = new TerminateMovementState();
            }
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
            sprite.Draw(spriteBatch, marioPhysics.Position());
        }

        public void FireFlower()
        {
            marioState.FireFlower();
        }

        public void Left()
        {
            movementState.Left();
        }

        public void RedMushroom()
        {
            marioState.RedMushroom();
        }

        public void Right()
        {
            movementState.Right();
        }

        public void TakeDamage()
        {
            marioState.TakeDamage();
        }

        public void Up()
        {
            movementState.Up();
        }

        public void Update()
        {
            movementState.Update();
            sprite.Update();
        }

        public void Idle()
        {
            movementState.Idle();
        }

        public Rectangle HitBox()
        {
            return new Rectangle(marioPhysics.XPosition(), marioPhysics.YPosition()- sprite.Height(), sprite.Width(), sprite.Height());
            // return new Rectangle(marioPhysics.XPosition(), marioPhysics.YPosition() - 32, 32, 32);
        }

        public void GreenMushroom()
        {
            // TODO
        }

        public void Obstacle()
        {
            movementState.Obstacle();
        }

        public void Coin()
        {
            //Do Nothing
        }
    }
}
