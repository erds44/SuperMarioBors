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
        event EventHandler ClearingScoresEvent;
        event EventHandler DestroyEvent;
        event EventHandler DeathStateEvent;
        event EventHandler SlidingEvent;
        event EventHandler ChangeToTeleportStateEvent;
        event EventHandler ChangeToFlagPoleStateEvent;
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
        void JumpingOffFlag(object sender, System.EventArgs e);
        void Teleport(Vector2 teleportPosition, Direction direction);
        void PowerPressed();
        void PowerReleased();
        void ResetVelocity();
        void EnterCastle();
    }
}
