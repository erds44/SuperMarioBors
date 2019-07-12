using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Mario.TransitionState;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Marios
{
    public interface IMario : IDynamic
    {
        event Action ClearingScoresEvent;
        event Action DestroyEvent;
        event Action DeathStateEvent;
        event Action <Vector2> SlidingEvent;
        event Action <Vector2>ChangeToTeleportStateEvent;
        event Action ChangeToFlagPoleStateEvent;
        int EnemyKillStreakCounter { get; set; }
        double NoMovementTimer { get; set; }
        bool OnGround { get; set; }
        ISprite Sprite { get; set; }
        IMarioHealthState HealthState { get; set; }
        IMarioMovementState MovementState { get; set; }
        IMarioTransitionState TransitionState { get; set; }
        void MoveLeft();
        void MoveDown();
        void MoveUp();
        void MoveRight();
        void Idle();
        new void Update(GameTime gameTime);
        void TakeFlower();
        void TakeRedMushroom();
        void TakeStar();
        void TakeDamage();
        void TimeOver();
        void SlidingFlagPole();
        void JumpingOffFlag();
        void Teleport(Vector2 teleportPosition, Direction direction);
        void PowerPressed();
        void PowerReleased();
        void ResetVelocity();
        void EnterCastle();
    }
}
