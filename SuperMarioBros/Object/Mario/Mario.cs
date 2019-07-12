using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects.Mario.MarioTransitionState;
using SuperMarioBros.Objects.Mario.TransitionState;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using SuperMarioBros.Stats;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Marios
{
    public class Mario : IMario
    {
        public int EnemyKillStreakCounter { get; set; } = 0;
        public event Action ClearingScoresEvent;
        public event Action ChangeToFlagPoleStateEvent;
        public event Action DestroyEvent;
        public event Action<Vector2> ChangeToTeleportStateEvent;
        public event Action DeathStateEvent;
        public event Action<Vector2> SlidingEvent;
        public ObjectState ObjState { get; set; }
        public IMarioHealthState HealthState { get; set; }
        public IMarioMovementState MovementState { get; set; }
        public ISprite Sprite { get; set; }
        public Physics Physics { get; set; }
        public Vector2 Position { get => position; set => position = value; }
        private Vector2 position;
        public bool OnGround { get; set; }
        public double NoMovementTimer { get; set; }
        public IMarioTransitionState TransitionState { get; set; }
        public Rectangle HitBox
        {
            get
            {
                Point size = SpriteFactory.ObjectSize(HealthState.GetType().Name + MovementState.GetType().Name);
                return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
            }
        }
        private readonly Dictionary<Direction, Vector2> teleportDictionary = new Dictionary<Direction, Vector2>
        {
            { Direction.top, new Vector2(0, -32)},
            { Direction.bottom, new Vector2(0, 35)},
            { Direction.left, new Vector2(-35, 0)},
            { Direction.right, new Vector2(35, 0)},
        };
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
        }

        public void MoveDown()
        {
            if(NoMovementTimer <= 0)
                MovementState.Down();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            TransitionState.Draw(spriteBatch);
        }

        public void MoveLeft()
        {
            if (NoMovementTimer <= 0)
                MovementState.Left();
        }

        public void MoveRight()
        {
            if (NoMovementTimer <= 0)
                MovementState.Right();
        }

        public void TakeDamage()
        {
            TransitionState.TakeDamage();
            if(HealthState is DeadMario) DeathStateEvent?.Invoke();
        }

        public void MoveUp()
        {
            if (NoMovementTimer <= 0)
                MovementState.Up();
        }


        public void Idle()
        {
            if (NoMovementTimer <= 0)
                MovementState.Idle();
        }

        public void Update(GameTime gameTime)
        {
            TransitionState.Update(gameTime);
            NoMovementTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (OnGround) EnemyKillStreakCounter = 1; //Reset it.
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
            if (!(HealthState is DeadMario)) HealthState = new DeadMario(this);
            DestroyEvent?.Invoke();
        }

        public void EnterCastle()
        {
            ClearingScoresEvent?.Invoke();
            StatsManager.Instance.CollectRemainingTime();
            ObjState = ObjectState.Destroy;
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

        public void TimeOver()
        {
            while (!(HealthState is DeadMario))
                HealthState.TakeDamage();
            DeathStateEvent?.Invoke();
        }

        public void SlidingFlagPole()
        {
            MovementState.SlidingFlagPole();
            SlidingEvent?.Invoke(Position);
            ChangeToFlagPoleStateEvent?.Invoke();
        }

        public void JumpingOffFlag()
        {
            if (MovementState is RightSliding)
                MovementState.ChangeSlidingDirection();
            else
                Position += new Vector2(20, 0);
            Physics.Velocity = new Vector2(100, -180);
            Physics.ApplyGravity();
        }

        public void Teleport(Vector2 teleportPosition, Direction direction)
        {
            ChangeToTeleportStateEvent?.Invoke(teleportPosition);
            if (teleportDictionary.TryGetValue(direction, out var tuple))
                Physics.SetConstentVelocity(tuple);

        }
        public void ResetVelocity()
        {
            Physics.ResetVelocity();
        }

        public void PowerPressed()
        {
            HealthState.PowerPressed();
        }

        public void PowerReleased()
        {
            HealthState.PowerReleased();
        }
    }
}
