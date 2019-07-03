using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.GameStates;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects.Mario.MarioTransitionState;
using SuperMarioBros.Objects.Mario.TransitionState;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Marios
{
    public class Mario : IMario
    {
        public int EnemyKillStreakCounter { get; set; }
        public event Action ClearingScoresEvent;
        public event Action DeathEvent;
        public event Action<Vector2> PowerUpEvent;
        public event Action<Vector2> ExtraLifeEvent;
        public event Action<Vector2> SlidingEvent;
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
        private bool isTeleporting = false;
        private Vector2 teleportPosition;
        private Vector2 expectedPosition;
        private readonly Dictionary<Direction, (Vector2, Vector2)> teleportDictionary = new Dictionary<Direction, (Vector2, Vector2)>
        {
            { Direction.top, (new Vector2(0, -25), new Vector2(0, -50))},
            { Direction.bottom, (new Vector2(0, 25), new Vector2(0, 50))},
            { Direction.left, (new Vector2(-25, 0), new Vector2(-50, 0))},
            { Direction.right, (new Vector2(25, 0), new Vector2(50, 0))},
        };
        public Mario(Vector2 location)
        {
            HealthState = new SmallMario(this);
            //HealthState = new BigMario(this);
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
            if (OnGround) EnemyKillStreakCounter = 1; //Reset it.
            if (NoMovementTimer <= 0)
            {
                HealthState.Update(gameTime);
                MovementState.Update(gameTime);
                Sprite.Update(gameTime);
                Position += Physics.Displacement(gameTime);
            }
            if(isTeleporting && (int)Position.Y == (int)expectedPosition.Y && (int)Position.X == (int)expectedPosition.X )
            {
                Position = teleportPosition;
                isTeleporting = false;
                Physics.ApplyGravity();
                MarioGame.Instance.ChangeToGameState();
            }
        }
        public void Destroy()
        {
            if (!(MarioGame.Instance.State is FlagPoleState))
            {
                DeathEvent?.Invoke();
                MarioGame.Instance.InitializeGame();
            }
            else
                ClearingScoresEvent?.Invoke();
        }

        public void TakeRedMushroom()
        {
            PowerUpEvent?.Invoke(Position);
            TransitionState.TakeRedMushroom();
        }

        public void TakeStar()
        {
            TransitionState.TakeStar();
        }

        public void TakeFlower()
        {
            PowerUpEvent?.Invoke(Position);
            TransitionState.OnFireFlower();
        }
        public void TakeGreenMushroom()
        {
            ExtraLifeEvent?.Invoke(Position);
        }

        public void TimeOver()
        {
            while (!(HealthState is DeadMario))
                HealthState.TakeDamage();
        }

        public void SlidingFlagPole()
        {
            MovementState.SlidingFlagPole();
            SlidingEvent?.Invoke(Position);
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

        public void TeleportDownWard(Vector2 teleportPosition, Direction direction)
        {
            isTeleporting = true;
            if(teleportDictionary.TryGetValue(direction, out var tuple))
            {
                expectedPosition += Position + tuple.Item2;
                Physics.Velocity = tuple.Item1;
                Physics.CurrentGravity = -200f; // to do 
            }
            this.teleportPosition = teleportPosition;
            MarioGame.Instance.ChangeToTeleportingState();
        }


        public void KeyDownUp()
        {
            if (!(HealthState is SmallMario))
                MovementState.Up();
        }
    }
}
