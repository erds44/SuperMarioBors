﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;
using System;
using System.Diagnostics;

namespace SuperMarioBros.Marios
{
    public class FlashingMario : IMario
    {
        public ObjectState ObjState { get => mario.ObjState; set => mario.ObjState = value; }
        public IMarioHealthState HealthState { get => mario.HealthState; set => mario.HealthState = value; }
        public IMarioMovementState MovementState { get => mario.MovementState ; set => mario.MovementState = value; }
        public MarioPhysics MarioPhysics { get => mario.MarioPhysics; }
        private readonly IMario mario;
        public ISprite Sprite { get; set; }
        private double timer;
        public Vector2 Position { get => mario.Position; set { } }
        public bool PowerFlag { get => mario.PowerFlag; set => mario.PowerFlag = value; }
        public double NoMovementTimer { get; set; }
        public MarioGame Game { get => mario.Game; set => mario.Game = value; }

        public FlashingMario(IMario mario)
        {
            this.mario = mario.ReturnItself();
            //this.HealthState = mario.HealthState;
            //MarioPhysics = mario.MarioPhysics;
            //HealthState = mario.HealthState;
            timer = 3;
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
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
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
            mario.Destroy();
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
