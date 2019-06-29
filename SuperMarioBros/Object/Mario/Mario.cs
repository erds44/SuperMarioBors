using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects.Mario.MarioTransitionState;
using SuperMarioBros.Objects.Mario.TransitionState;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Marios
{
    public class Mario : IMario
    {
        public event Action deathEvent;
        public ObjectState ObjState { get; set; }
        public bool PowerFlag { get; set; }
        public bool KeyUpPower { get; set; }
        public IMarioHealthState HealthState { get; set; }
        public IMarioMovementState MovementState { get; set; }
        public ISprite Sprite { get; set; }
        public Physics Physics { get; set; }
        public Vector2 Position { get => position; set => position = value; }
        private Vector2 position;
        public bool OnGround { get; set; }
        public double NoMovementTimer { get; set; }
        public IMarioTransitionState TransitionState { get; set; }
        public Mario(Vector2 location)
        {
            HealthState = new SmallMario(this);
            Physics = new Physics(new Vector2(0,0), 800f, 200f, 150f);
            Physics.ApplyGravity();
            MovementState = new RightIdle(this);
            TransitionState = new NormalState(this);
            Position = location;
            NoMovementTimer = 0;
            ObjState = ObjectState.Normal;
            KeyUpPower = true;
        }

        public void Down()
        {
            if(NoMovementTimer <= 0)
                MovementState.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            TransitionState.Draw(spriteBatch);
        }

        public void Left()
        {
            if (NoMovementTimer <= 0)
                MovementState.Left();
        }

        public void Right()
        {
            if (NoMovementTimer <= 0)
                MovementState.Right();
        }

        public void TakeDamage()
        {
            TransitionState.TakeDamage();
        }

        public void Up()
        {
            if (NoMovementTimer <= 0)
                MovementState.Up();
        }


        public void Idle()
        {
            if (NoMovementTimer <= 0)
                MovementState.Idle();
        }

        public Rectangle HitBox()
        {
            Point size = SpriteFactory.ObjectSize(HealthState.GetType().Name + MovementState.GetType().Name);
            return new Rectangle((int)Position.X, (int)Position.Y- size.Y, size.X, size.Y);
        }

        public void Update(GameTime gameTime)
        {
            TransitionState.Update(gameTime);
            NoMovementTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (NoMovementTimer <= 0)
            {
                HealthState.Update(gameTime);
                MovementState.Update(gameTime);
                Sprite.Update(gameTime);
                Position += Physics.Displacement(gameTime);
            }
        }
        public void Destroy()
        {
            OnMarioDeath();
            MarioGame.Instance.InitializeGame();
        }

        protected virtual void OnMarioDeath()
        {
            deathEvent?.Invoke();
        }

        public void TakeRedMushroom()
        {
            TransitionState.TakeRedMushroom();
        }

        public void TakeStar()
        {
            TransitionState.TakeStar();
        }

        public void TakeFlower()
        {
            TransitionState.OnFireFlower();
        }
    }
}
